using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingStore.Core.Models.Product;
using ClothingStore.Infrastructure.Data.Entities;

namespace ClothingStore.Core.Contracts
{
    public interface IProductService
    {
        public Task<Product> CreateProductAsync(ProductDTO productDTO);
        public Task<Product> UpdateProductAsync(int id, ProductDTO productDTO);
        public Task<bool> DeleteProductAsync(int id);
        public Task<List<ProductDTO>> GetAllAsync();
        public Task<ProductDTO> GetByIdAsync(int id);


    }
}
