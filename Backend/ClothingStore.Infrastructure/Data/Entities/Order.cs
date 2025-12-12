using System;
using System.Collections.Generic;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        // Relations
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }

        // Status
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        // Pricing
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalAmount { get; set; }

        // Delivery snapshot
        public string DeliveryFullName { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryPostalCode { get; set; }

        // Courier tracking
        public string CourierName { get; set; }
        public string TrackingNumber { get; set; }

        // Order items (relationship)
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        // Payment relation
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        AwaitingPayment,
        Paid,
        Shipped,
        Delivered,
        Cancelled,
        Refunded
    }
}
