using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingStore.Core.Models.PagedResults;
using ClothingStore.Core.Models.Product;
using ClothingStore.Infrastructure.Data.Entities;

namespace ClothingStore.Core.Contracts
{
    public interface IProductService
    {
        public Task<Product> CreateProductAsync(ProductCreateDTO productDTO);
        public Task UpdateProductAsync(int id, ProductUpdateDTO productDTO);
        public Task<bool> DeleteProductAsync(int id);
        public Task<List<ProductDTO>> GetAllAsync();    
        public Task<ProductDTO> GetByIdAsync(int id);
        public Task<PagedResultDTO<ProductDTO>> FilterAsync(
            ProductFilterDTO filterDTO, 
            int page,
            int pageSize);
        public Task<ProductFilterOptionsDTO> GetFilterOptionsAsync();


    }
}
