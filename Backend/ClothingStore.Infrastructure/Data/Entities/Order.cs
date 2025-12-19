using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public enum OrderStatus
    {
        Pending = 0,
        Processing = 1,
        Completed = 2,
        Cancelled = 3,
        Paid = 4
    }

    public enum PaymentMethod
    {
        CashOnDelivery = 0,
        PayPal = 1
    }

    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Required]
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CashOnDelivery;

        [MaxLength(64)]
        public string? PayPalOrderId { get; set; }

        public DateTime? PaidAt { get; set; }

        public int? SpeedyOfficeId { get; set; }

        [MaxLength(300)]
        public string? SpeedyOfficeLabel { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
