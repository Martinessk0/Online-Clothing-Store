using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

namespace ClothingStore.Core.Models.Store
{
    public class OrderCreateDto
    {
        public string UserId { get; set; } = null!;

        public List<OrderItemCreateDto> Items { get; set; } = new();

        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalAmount { get; set; }

        // Данни за доставка
        public string DeliveryFullName { get; set; } = null!;
        public string DeliveryPhone { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public string DeliveryCity { get; set; } = null!;
        public string DeliveryPostalCode { get; set; } = null!;

        // Курир/тийнг
        public string CourierName { get; set; } = null!;
        public string TrackingNumber { get; set; } = null!;

        // Начален статус
        public string Status { get; set; } = "Pending";
    }
}
