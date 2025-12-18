using ClothingStore.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Core.Models.Order
{
    public class OrderCreateDto
    {
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        public int? SpeedyOfficeId { get; set; }
        public string? SpeedyOfficeLabel { get; set; }

        [MinLength(1)]
        public List<OrderCreateItemDto> Items { get; set; } = new List<OrderCreateItemDto>();
    }
}
