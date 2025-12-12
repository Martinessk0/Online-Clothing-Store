using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Core.Models.Store
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        // ТУК използваме същото име,
        // което вече си ползвал в CategoryService: ParentID
        public int? ParentID { get; set; }

        public bool IsActive { get; set; }
    }
}
