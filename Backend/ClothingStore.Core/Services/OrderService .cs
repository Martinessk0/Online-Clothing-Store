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

        public OrderService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> CreateOrderAsync(OrderCreateDto dto, string? userId)
        {
            if (dto.Items == null || dto.Items.Count == 0)
            {
                throw new ArgumentException("Order must contain at least one item.");
            }

            var productIds = dto.Items
                .Select(i => i.ProductId)
                .Distinct()
                .ToList();

            var products = await repo.AllReadonly<Product>()
                .Include(p => p.Variants)
                .Where(p => productIds.Contains(p.Id) && p.IsActive)
                .ToListAsync();

            if (products.Count != productIds.Count)
            {
                throw new ArgumentException("One or more products are not available.");
            }

            var variantIds = dto.Items
                .Where(i => i.ProductVariantId.HasValue)
                .Select(i => i.ProductVariantId!.Value)
                .Distinct()
                .ToList();

            List<ProductVariant> variants = new();

            if (variantIds.Any())
            {
                variants = await repo.AllReadonly<ProductVariant>()
                    .Include(v => v.Color)
                    .Where(v => variantIds.Contains(v.Id) && v.IsActive)
                    .ToListAsync();
            }

            var order = new Order
            {
                UserId = userId,
                CustomerName = dto.CustomerName ?? string.Empty,
                Email = dto.Email ?? string.Empty,
                Phone = dto.Phone ?? string.Empty,
                Address = dto.Address ?? string.Empty,
                PaymentMethod = dto.PaymentMethod,
                Status = OrderStatus.Pending,
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
                    {
                        throw new ArgumentException("Invalid product variant in order.");
                    }

                    if (variant.Stock < quantity)
                    {
                        throw new ArgumentException("Not enough stock for selected variant.");
                    }
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
            {
                query = query.Where(o => o.UserId == userId);
            }

            var order = await query.FirstOrDefaultAsync();

            if (order == null)
            {
                return null;
            }

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
    }
}
