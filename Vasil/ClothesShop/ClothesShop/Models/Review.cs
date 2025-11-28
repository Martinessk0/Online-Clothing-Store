using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Hidden

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        // Методи според заданието
        public void Publish()
        {
            Status = "Approved";
        }

        public void Hide()
        {
            Status = "Hidden";
        }
    }
}
