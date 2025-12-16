namespace ClothingStore.Core.Models.Product
{
    public class ProductImageCreateDto
    {
        public string Url { get; set; } = string.Empty;
        public string PublicId { get; set; } = string.Empty;
        public bool IsMain { get; set; }
    }
}
