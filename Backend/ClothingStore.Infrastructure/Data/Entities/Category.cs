using System.Collections.Generic;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }                  // Primary Key

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
