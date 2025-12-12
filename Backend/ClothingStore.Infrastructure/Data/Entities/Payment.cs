using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        // Paypal-specific fields:
        public string Provider { get; set; } = "PayPal";
        public string PaymentIntentId { get; set; }    // PayPal Order ID
        public string TransactionId { get; set; }      // Capture ID

        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";

        public PaymentStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Authorized,
        Paid,
        Failed,
        Refunded
    }
}
