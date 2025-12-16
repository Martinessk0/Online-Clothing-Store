namespace ClothingStore.Core.Models.Product
{
    public class ProductImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public bool IsMain { get; set; }
    }
}
