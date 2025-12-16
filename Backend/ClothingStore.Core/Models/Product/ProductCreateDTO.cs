using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models.Product
{
    public class ProductCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public string Brand { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public List<ProductVariantCreateDTO> Variants { get; set; } = new();

        public List<ProductImageCreateDto> Images { get; set; } = new();
    }
}
