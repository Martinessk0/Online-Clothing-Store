namespace ClothingStore.Core.Models.Product
{
    public class ProductFilterOptionsDTO
    {
        public List<string> Brands { get; set; } = new();
        public List<string> Sizes { get; set; } = new();
        public List<string> Colors { get; set; } = new();
    }
}
