namespace ClothingStore.Core.Models.Recommendation
{
    public class TrackInteractionDto
    {
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }

        public string? AnonymousId { get; set; }

        public string Type { get; set; } = string.Empty;

        public int? DurationSeconds { get; set; }

        public string? Payload { get; set; }
    }
}
