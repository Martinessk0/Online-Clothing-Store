using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Core.Models.Store
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;

        public int? ParentID { get; set; }
    }
}
