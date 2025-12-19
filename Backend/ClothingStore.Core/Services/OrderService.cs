using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Order;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repo;
        private readonly ISpeedyService speedy;

        public OrderService(IRepository repo, ISpeedyService speedy)
        {
            this.repo = repo;
            this.speedy = speedy;
        }

        public async Task<int> CreateOrderAsync(OrderCreateDto dto, string? userId)
        {
            if (dto.Items == null || dto.Items.Count == 0)
                throw new ArgumentException("Order must contain at least one item.");

            // Само COD + PayPal
            if (dto.PaymentMethod != PaymentMethod.CashOnDelivery &&
                dto.PaymentMethod != PaymentMethod.PayPal)
            {
                throw new ArgumentException("Невалиден метод на плащане.");
            }

            var productIds = dto.Items.Select(i => i.ProductId).Distinct().ToList();

            var products = await repo.AllReadonly<Product>()
                .Include(p => p.Variants)
                .Where(p => productIds.Contains(p.Id) && p.IsActive)
                .ToListAsync();

            if (products.Count != productIds.Count)
                throw new ArgumentException("One or more products are not available.");

            var variantIds = dto.Items
                .Where(i => i.ProductVariantId.HasValue)
                .Select(i => i.ProductVariantId!.Value)
                .Distinct()
                .ToList();

            List<ProductVariant> variants = new();
            if (variantIds.Any())
            {
                variants = await repo.All<ProductVariant>()   // важно: All (НЕ Readonly), защото ще update-ваме stock
                    .Include(v => v.Color)
                    .Where(v => variantIds.Contains(v.Id) && v.IsActive)
                    .ToListAsync();
            }

            // Address (Speedy офис)
            string addressToStore = dto.Address ?? string.Empty;

            if (dto.SpeedyOfficeId.HasValue)
            {
                var office = await speedy.GetOfficeByIdAsync(dto.SpeedyOfficeId.Value);

                var label = dto.SpeedyOfficeLabel;
                if (office != null)
                {
                    label = $"{office.Name}, {office.AddressFull}".Trim().Trim(',');
                }

                addressToStore = $"Speedy офис: {label}";
            }

            // Статус при създаване:
            // - PayPal -> Pending (не е платена още)
            // - COD -> Pending (или Processing ако искаш)
            var initialStatus = OrderStatus.Pending;

            var order = new Order
            {
                UserId = userId,
                CustomerName = dto.CustomerName ?? string.Empty,
                Email = dto.Email ?? string.Empty,
                Phone = dto.Phone ?? string.Empty,
                Address = addressToStore,
                SpeedyOfficeId = dto.SpeedyOfficeId,
                SpeedyOfficeLabel = dto.SpeedyOfficeLabel,
                PaymentMethod = dto.PaymentMethod,
                Status = initialStatus,
                CreatedAt = DateTime.UtcNow
            };

            foreach (var item in dto.Items)
            {
                var product = products.First(p => p.Id == item.ProductId);

                var quantity = item.Quantity <= 0 ? 1 : item.Quantity;
                var unitPrice = product.Price;

                ProductVariant? variant = null;

                if (item.ProductVariantId.HasValue)
                {
                    variant = variants.FirstOrDefault(v => v.Id == item.ProductVariantId.Value);

                    if (variant == null || variant.ProductId != product.Id)
                        throw new ArgumentException("Invalid product variant in order.");

                    if (variant.Stock < quantity)
                        throw new ArgumentException("Not enough stock for selected variant.");
                }

                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    ProductVariantId = variant?.Id,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    LineTotal = unitPrice * quantity,
                    ColorName = variant?.Color?.Name,
                    Size = variant?.Size
                };

                order.Items.Add(orderItem);

                // ✅ Резервация на stock при CreateOrder
                // PayPal неплатено -> timeout job ще върне stock
                // COD -> остава намален, защото поръчката е “реална”
                if (variant != null)
                {
                    variant.Stock -= quantity;
                    repo.Update(variant);
                }
            }

            order.TotalAmount = order.Items.Sum(i => i.LineTotal);

            await repo.AddAsync(order);
            await repo.SaveChangesAsync();

            return order.Id;
        }

        public async Task<OrderDto?> GetOrderAsync(int id, string? userId)
        {
            var query = repo.AllReadonly<Order>()
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.Images)
                .Include(o => o.Items)
                    .ThenInclude(i => i.ProductVariant)
                        .ThenInclude(v => v!.Color)
                .Where(o => o.Id == id);

            if (!string.IsNullOrEmpty(userId))
                query = query.Where(o => o.UserId == userId);

            var order = await query.FirstOrDefaultAsync();
            if (order == null) return null;

            var dto = new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                Email = order.Email,
                Phone = order.Phone,
                Address = order.Address,
                PaymentMethod = order.PaymentMethod.ToString(),
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                CreatedAt = order.CreatedAt
            };

            foreach (var item in order.Items)
            {
                var imageUrl = item.Product.Images
                    .OrderByDescending(img => img.IsMain)
                    .ThenBy(img => img.SortOrder)
                    .Select(img => img.Url)
                    .FirstOrDefault();

                dto.Items.Add(new OrderItemDto
                {
                    ProductId = item.ProductId,
                    ProductVariantId = item.ProductVariantId,
                    Name = item.Product.Name,
                    ImageUrl = imageUrl,
                    ColorName = item.ColorName,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }

            return dto;
        }

        public async Task<IEnumerable<OrderDto>> GetUserOrdersAsync(string userId)
        {
            return await repo
                .AllReadonly<Order>()
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    CustomerName = o.CustomerName!,
                    Email = o.Email!,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status.ToString(),
                    CreatedAt = o.CreatedAt,
                    Items = o.Items.Select(i => new OrderItemDto
                    {
                        ProductId = i.ProductId,
                        ProductVariantId = i.ProductVariantId,
                        Name = i.Product.Name,
                        ColorName = i.ColorName,
                        Size = i.Size,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminOrderListItemDto>> GetAllOrdersAsync()
        {
            return await repo
                .AllReadonly<Order>()
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new AdminOrderListItemDto
                {
                    Id = o.Id,
                    CustomerName = o.CustomerName,
                    Email = o.Email,
                    Phone = o.Phone,
                    Address = o.Address,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status.ToString(),
                    CreatedAt = o.CreatedAt,
                    ItemsCount = o.Items.Count
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, string newStatus)
        {
            var order = await repo.GetByIdAsync<Order>(orderId);
            if (order == null) return false;

            if (!Enum.TryParse<OrderStatus>(newStatus, ignoreCase: true, out var statusEnum))
                return false;

            // (По желание) защита: да не се “разплатят” платени поръчки през админ панела
            if (order.Status == OrderStatus.Paid && statusEnum != OrderStatus.Paid)
                return false;

            order.Status = statusEnum;
            await repo.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<string>> GetAllStatusesAsync()
        {
            var names = Enum.GetNames(typeof(OrderStatus)).AsEnumerable();
            return Task.FromResult(names);
        }
    }
}
