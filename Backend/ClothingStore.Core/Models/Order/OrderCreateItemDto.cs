namespace ClothingStore.Core.Models.Order
{
    public class OrderCreateItemDto
    {
        public int ProductId { get; set; }
        public int? ProductVariantId { get; set; }
        public int Quantity { get; set; }
    }
}
