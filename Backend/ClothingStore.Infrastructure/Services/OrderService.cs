using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Store;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => MapToDto(o))
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderDto>> GetByUserAsync(string userId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => MapToDto(o))
                .ToListAsync();
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);

            return entity == null ? null : MapToDto(entity);
        }

        public async Task<int> CreateAsync(OrderCreateDto model)
        {
            if (model.Items == null || model.Items.Count == 0)
            {
                throw new InvalidOperationException("Order must have at least one item.");
            }

            // Ако искаш – тук можем да игнорираме model.Subtotal и да го изчислим сами:
            var subtotal = model.Items.Sum(i => i.UnitPrice * i.Quantity);
            var total = subtotal + model.ShippingCost;

            var order = new Order
            {
                UserId = model.UserId,

                Subtotal = subtotal,
                ShippingCost = model.ShippingCost,
                TotalAmount = total,

                DeliveryFullName = model.DeliveryFullName,
                DeliveryPhone = model.DeliveryPhone,
                DeliveryAddress = model.DeliveryAddress,
                DeliveryCity = model.DeliveryCity,
                DeliveryPostalCode = model.DeliveryPostalCode,

                CourierName = model.CourierName,
                TrackingNumber = model.TrackingNumber,

                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            order.Items = model.Items
                .Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                })
                .ToList();

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task UpdateAsync(int id, OrderUpdateDto model)
        {
            var entity = await _context.Orders.FindAsync(id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Order {id} not found");
            }

            if (!string.IsNullOrWhiteSpace(model.Status) &&
                Enum.TryParse<OrderStatus>(model.Status, out var parsedStatus))
            {
                entity.Status = parsedStatus;
            }

            if (model.PaidAt.HasValue)
            {
                entity.PaidAt = model.PaidAt;
            }

            if (model.ShippedAt.HasValue)
            {
                entity.ShippedAt = model.ShippedAt;
            }

            if (model.DeliveredAt.HasValue)
            {
                entity.DeliveredAt = model.DeliveredAt;
            }

            if (!string.IsNullOrWhiteSpace(model.TrackingNumber))
            {
                entity.TrackingNumber = model.TrackingNumber;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Orders.FindAsync(id);
            if (entity == null)
            {
                return;
            }

            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, OrderStatusUpdateDto model)
        {
            var entity = await _context.Orders.FindAsync(id)
                ?? throw new KeyNotFoundException($"Order {id} not found");

            if (!Enum.TryParse<OrderStatus>(model.Status, out var parsedStatus))
            {
                throw new ArgumentException("Invalid status value", nameof(model.Status));
            }

            entity.Status = parsedStatus;
            await _context.SaveChangesAsync();
        }

        private static OrderDto MapToDto(Order o)
        {
            return new OrderDto
            {
                Id = o.Id,
                UserId = o.UserId,
                CreatedAt = o.CreatedAt,
                PaidAt = o.PaidAt,
                ShippedAt = o.ShippedAt,
                DeliveredAt = o.DeliveredAt,
                Status = o.Status.ToString(),
                Subtotal = o.Subtotal,
                ShippingCost = o.ShippingCost,
                TotalAmount = o.TotalAmount,
                DeliveryFullName = o.DeliveryFullName,
                DeliveryPhone = o.DeliveryPhone,
                DeliveryAddress = o.DeliveryAddress,
                DeliveryCity = o.DeliveryCity,
                DeliveryPostalCode = o.DeliveryPostalCode,
                CourierName = o.CourierName,
                TrackingNumber = o.TrackingNumber,
                Items = o.Items?
                    .Select(i => new OrderItemDto
                    {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice
                    })
                    .ToList() ?? new List<OrderItemDto>()
            };
        }
    }
}
