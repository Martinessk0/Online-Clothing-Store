using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        // 🔹 Добавяме ParentId – това го ползва CategoryService
        public int? ParentId { get; set; }

        // (по желание) навигации за йерархия, не са задължителни,
        // но няма да пречат:
        public Category? ParentCategory { get; set; }

        public ICollection<Category> Subcategories { get; set; } = new List<Category>();

        // Навигация към продуктите
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
