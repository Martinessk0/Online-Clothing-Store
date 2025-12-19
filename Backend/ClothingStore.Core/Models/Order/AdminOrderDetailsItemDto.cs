namespace ClothingStore.Core.Models.Order
{
    public class AdminOrderDetailsItemDto
    {
        public int ProductId { get; set; }
        public int? ProductVariantId { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public string? ColorName { get; set; }
        public string? Size { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
