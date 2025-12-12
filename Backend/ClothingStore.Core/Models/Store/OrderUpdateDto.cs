using System;

namespace ClothingStore.Core.Models.Store
{
    public class OrderUpdateDto
    {
        public string Status { get; set; }

        public string TrackingNumber { get; set; }
        public string CourierName { get; set; }

        public DateTime? PaidAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}
