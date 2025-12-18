using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Core.Models.Order
{
    public class UpdateOrderStatusDto
    {
        [Required]
        public string Status { get; set; } = string.Empty;
    }
}
