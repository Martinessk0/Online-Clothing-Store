using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string Brand { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public bool IsActive { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    }
}
