namespace ClothingStore.Core.Models.Order
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int? ProductVariantId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ColorName { get; set; }

        public string? ImageUrl { get; set; }

        public string? Size { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal => UnitPrice * Quantity;
    }

}
