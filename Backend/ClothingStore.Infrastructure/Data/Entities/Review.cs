using System;
using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
