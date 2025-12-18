namespace ClothingStore.Core.Models.Order
{
    public class AdminOrderListItemDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public int ItemsCount { get; set; }
    }
}
