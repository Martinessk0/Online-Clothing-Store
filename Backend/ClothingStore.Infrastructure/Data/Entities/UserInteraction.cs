using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public enum InteractionType
    {
        ProductView = 0,
        AddToCart = 1,
        Purchase = 2,
        CategoryView = 3,
        Search = 4
    }

    public class UserInteraction
    {
        [Key]
        public int Id { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [MaxLength(64)]
        public string? AnonymousId { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        public InteractionType Type { get; set; }

        public int? DurationSeconds { get; set; }

        [MaxLength(256)]
        public string? Payload { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
