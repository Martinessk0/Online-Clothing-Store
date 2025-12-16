using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Product;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Core.Services
{
    public class ProductService : IProductService
    {
        private IRepository repo;

        public ProductService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Product> CreateProductAsync(ProductCreateDTO productDTO)
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
                Price = productDTO.Price,
                Brand = productDTO.Brand,
                Size = productDTO.Size,
                Color = productDTO.Color,
                Stock = productDTO.Stock,
                CategoryId = productDTO.CategoryId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, ProductUpdateDTO productDTO)
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
            product.Brand = productDTO.Brand;
            product.Size = productDTO.Size;
            product.Color = productDTO.Color;
            product.Stock = productDTO.Stock;

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
                    Brand = p.Brand,
                    Size = p.Size,
                    Color = p.Color,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId
                }).FirstAsync();
        }

        public async Task<List<Product>> FilterAsync(ProductDTO filterDTO)
        {
            var filteredProducts = await repo.AllReadonly<Product>()
                .WhereIf(!string.IsNullOrEmpty(filterDTO.Name), p => p.Name == filterDTO.Name)
                .WhereIf(filterDTO.Price > 0, p => p.Price == filterDTO.Price)
                .WhereIf(!string.IsNullOrEmpty(filterDTO.Brand), p => p.Brand == filterDTO.Brand)
                .WhereIf(!string.IsNullOrEmpty(filterDTO.Size), p => p.Size == filterDTO.Size)
                .WhereIf(!string.IsNullOrEmpty(filterDTO.Color), p => p.Color == filterDTO.Color)
                .ToListAsync();

            return filteredProducts;
        }
    }
}
