using ClothingStore.Core.Models.ProductReview;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public string Brand { get; set; } = string.Empty;
        public int CategoryId { get; set; }

        public double AverageRating { get; set; }
        public int ReviewCount { get; set; }
        public List<ReviewDto> Reviews { get; set; } = new();

        public DateTime? CreatedAt { get; set; }

        public List<ProductVariantDTO> Variants { get; set; } = new();

        public List<ProductImageDto> Images { get; set; } = new();
    }
}
