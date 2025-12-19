namespace ClothingStore.Core.Models.Order
{
    public class AdminOrderDetailsDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Status { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime? PaidAt { get; set; }

        public int? SpeedyOfficeId { get; set; }
        public string? SpeedyOfficeLabel { get; set; }

        public string? PayPalOrderId { get; set; }

        public List<AdminOrderDetailsItemDto> Items { get; set; } = new();
    }
}
