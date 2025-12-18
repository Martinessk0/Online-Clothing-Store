namespace ClothingStore.Core.Models.Speedy
{
    public class SpeedyOptions
    {
        public string BaseUrl { get; set; } = "https://api.speedy.bg/v1";
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Language { get; set; } = "BG";
    }
}
