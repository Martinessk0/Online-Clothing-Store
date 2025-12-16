namespace ClothingStore.Core.Models.Product
{
    public class ProductVariantCreateDTO
    {
        public int ColorId { get; set; }
        public string Size { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}
