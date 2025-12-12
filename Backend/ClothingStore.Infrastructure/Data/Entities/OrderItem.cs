using System;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        // Ако по-късно добавите Product entity, може да върнете това:
        // public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }       // Snapshot of product price

        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
