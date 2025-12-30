using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models.Product
{
    public class ProductFilterDTO
    {
        public string? Keyword { get; set; }          
        public string? Brand { get; set; }            
        public decimal? MinPrice { get; set; }        
        public decimal? MaxPrice { get; set; }        
        public bool? InStockOnly { get; set; }        
        public string? Color { get; set; }            
        public string? Size { get; set; }             
        public string? SortBy { get; set; }           
    }

}
