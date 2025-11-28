using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? ParentID { get; set; }
        public bool IsActive { get; set; } = true;
    }
}