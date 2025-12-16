namespace ClothingStore.Core.Models.Product
{
    public class ProductVariantDTO
    {
        public int Id { get; set; }

        public int ColorId { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public string? ColorHex { get; set; }

        public string Size { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}
