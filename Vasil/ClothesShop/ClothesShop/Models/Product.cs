using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
        public int? CategoryID { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(100)]
        public string Material { get; set; }

        public int StockQuantity { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}