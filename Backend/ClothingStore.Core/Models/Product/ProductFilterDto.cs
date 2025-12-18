using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models.Product
{
    public class ProductFilterDTO
    {
        public string? Keyword { get; set; }          // search in Name, Description, Brand
        public string? Brand { get; set; }            // exact brand filter
        public decimal? MinPrice { get; set; }        // minimum price
        public decimal? MaxPrice { get; set; }        // maximum price
        public bool? InStockOnly { get; set; }        // only products with stock > 0
        public string? Color { get; set; }            // optional: filter by variant color name
        public string? Size { get; set; }             // optional: filter by variant size
        public string? SortBy { get; set; }           // "PriceAsc", "PriceDesc", "Newest", "Oldest"
    }

}
