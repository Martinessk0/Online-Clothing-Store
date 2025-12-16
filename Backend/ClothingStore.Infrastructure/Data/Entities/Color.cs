namespace ClothingStore.Infrastructure.Data.Entities
{
    public class Color
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;   // "black", "white", "navy"

        public string Name { get; set; } = string.Empty;   // "Черен", "Бял"

        public string? Hex { get; set; }                   // "#000000"

        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
