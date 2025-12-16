namespace ClothingStore.Infrastructure.Data.Entities
{
    public class ProductVariant
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;

        public string Size { get; set; } = string.Empty;
        public int Stock { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
