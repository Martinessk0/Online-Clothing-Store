namespace ClothingStore.Core.Models.Color
{
    public class ColorDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Hex { get; set; }
    }
}
