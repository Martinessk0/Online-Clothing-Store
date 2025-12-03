using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Product;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Services
{
    public class ProductService : IProductService
    {
        private IRepository repo;

        public ProductService (IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Product> CreateProductAsync(ProductDTO productDTO)
        {
            var category = await repo.AllReadonly<Category>()
                                     .FirstOrDefaultAsync(c => c.Id == productDTO.CategoryId);

            if (category == null)
            {
                throw new ArgumentException("Category not found");
            }

            var product = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price= productDTO.Price,
                Brand= productDTO.Brand,
                Size = productDTO.Size,
                Color= productDTO.Color,
                Stock = productDTO.Stock,
                CategoryId = productDTO.CategoryId,
                IsActive =true,
                CreatedAt=DateTime.UtcNow
            };

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, ProductDTO productDTO)
        {
            Product product = await repo.GetByIdAsync<Product>(id);

            if (product == null || !product.IsActive)
            {
                throw new ArgumentException("Product not found");
            }

            Category? category = await repo.AllReadonly<Category>()
                                     .FirstOrDefaultAsync(c => c.Id == productDTO.CategoryId);

            if (category == null)
            {
                throw new ArgumentException($"Category not found {productDTO.CategoryId}");
            }

            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.CategoryId = category.Id;
            product.ModifiedAt = DateTime.UtcNow;

            repo.Update(product);
            await repo.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            Product product = await repo.GetByIdAsync<Product>(id);

            if (product == null || !product.IsActive)
            {
                throw new ArgumentException("Product not found");
            }

            product.IsActive = false;
            product.ModifiedAt = DateTime.UtcNow;

            repo.Update(product);
            await repo.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            return await repo.AllReadonly<Product>().Where(p => p.IsActive).Select(p => new ProductDTO()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Brand = p.Brand,
                Size = p.Size,
                Color = p.Color,
                Stock = p.Stock,
                CategoryId = p.CategoryId,

            }).ToListAsync();
        }


        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            return await repo.AllReadonly<Product>()
                .Where(p => p.IsActive && p.Id == id)
                .Select(p => new ProductDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.Category.Id,
                }).FirstAsync();
        }
    }
}
