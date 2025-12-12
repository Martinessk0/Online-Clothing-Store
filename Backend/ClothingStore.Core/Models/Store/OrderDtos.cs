namespace ClothingStore.Core.Models.Store
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }

        public string Status { get; set; } = null!;

        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalAmount { get; set; }

        public string DeliveryFullName { get; set; } = null!;
        public string DeliveryPhone { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public string DeliveryCity { get; set; } = null!;
        public string DeliveryPostalCode { get; set; } = null!;

        public string CourierName { get; set; } = null!;
        public string TrackingNumber { get; set; } = null!;

        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
