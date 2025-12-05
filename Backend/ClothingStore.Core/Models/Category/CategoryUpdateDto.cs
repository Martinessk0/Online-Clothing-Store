using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Core.Models.Store
{
    public class CategoryUpdateDto
    {
        [Required]
        public string Name { get; set; } = null!;

        public int? ParentID { get; set; }

        public bool IsActive { get; set; }
    }
}
