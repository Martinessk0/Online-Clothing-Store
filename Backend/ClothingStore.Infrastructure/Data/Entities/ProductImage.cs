namespace ClothingStore.Infrastructure.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public string Url { get; set; } = string.Empty;
        public string PublicId { get; set; } = string.Empty;

        public bool IsMain { get; set; } = false;
        public int SortOrder { get; set; } = 0;
    }
}
