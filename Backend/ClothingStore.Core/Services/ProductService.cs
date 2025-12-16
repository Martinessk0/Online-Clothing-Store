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
                CategoryId = productDTO.CategoryId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            foreach (var v in productDTO.Variants)
            {
                var colorExists = await repo.AllReadonly<Color>()
                                            .AnyAsync(c => c.Id == v.ColorId);

                if (!colorExists)
                {
                    throw new ArgumentException($"Color not found: {v.ColorId}");
                }

                product.Variants.Add(new ProductVariant
                {
                    ColorId = v.ColorId,
                    Size = v.Size,
                    Stock = v.Stock,
                    IsActive = true
                });
            }

            foreach (var img in productDTO.Images)
            {
                product.Images.Add(new ProductImage
                {
                    Url = img.Url,
                    PublicId = img.PublicId,
                    IsMain = img.IsMain
                });
            }

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            return product;
        }

        public async Task UpdateProductAsync(int id, ProductUpdateDTO productDTO)
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

            var existingImages = await repo.All<ProductImage>()
         .Where(pi => pi.ProductId == id)
         .ToListAsync();

            foreach (var img in existingImages)
            {
                repo.Delete(img);
            }

            int sortOrder = 0;

            if (productDTO.Images.Any() && !productDTO.Images.Any(i => i.IsMain))
            {
                productDTO.Images[0].IsMain = true;
            }

            foreach (var imgDto in productDTO.Images)
            {
                await repo.AddAsync(new ProductImage
                {
                    ProductId = id,
                    Url = imgDto.Url,
                    PublicId = imgDto.PublicId,
                    IsMain = imgDto.IsMain,
                    SortOrder = sortOrder++
                });
            }


            repo.Update(product);
            await repo.SaveChangesAsync();
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
            return await repo.AllReadonly<Product>()
                .Where(p => p.IsActive)
                .Include(p => p.Images)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Color)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Brand = p.Brand,
                    CategoryId = p.CategoryId,
                    Variants = p.Variants
                        .Where(v => v.IsActive)
                        .Select(v => new ProductVariantDTO
                        {
                            Id = v.Id,
                            ColorId = v.ColorId,
                            ColorName = v.Color.Name,
                            ColorHex = v.Color.Hex,
                            Size = v.Size,
                            Stock = v.Stock
                        })
                        .ToList(),
                    Images = p.Images
                    .OrderBy(i => i.SortOrder)
                    .Select(i => new ProductImageDto
                    {
                        Id = i.Id,
                        Url = i.Url,
                        IsMain = i.IsMain
                    })
                    .ToList()
                })
                .ToListAsync();
        }


        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            return await repo.AllReadonly<Product>()
                .Where(p => p.IsActive && p.Id == id)
                .Include(p => p.Images)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Color)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Brand = p.Brand,
                    CategoryId = p.CategoryId,
                    Variants = p.Variants
                        .Where(v => v.IsActive)
                        .Select(v => new ProductVariantDTO
                        {
                            Id = v.Id,
                            ColorId = v.ColorId,
                            ColorName = v.Color.Name,
                            ColorHex = v.Color.Hex,
                            Size = v.Size,
                            Stock = v.Stock
                        })
                        .ToList(),
                    Images = p.Images
                    .OrderBy(i => i.SortOrder)
                    .Select(i => new ProductImageDto
                    {
                        Id = i.Id,
                        Url = i.Url,
                        IsMain = i.IsMain
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> FilterAsync(ProductDTO filterDTO)
        {
            var filteredProducts = await repo.AllReadonly<Product>()
                .WhereIf(!string.IsNullOrEmpty(filterDTO.Name), p => p.Name == filterDTO.Name)
                .WhereIf(filterDTO.Price > 0, p => p.Price == filterDTO.Price)
                .WhereIf(!string.IsNullOrEmpty(filterDTO.Brand), p => p.Brand == filterDTO.Brand)
                //.WhereIf(!string.IsNullOrEmpty(filterDTO.Size), p => p.Size == filterDTO.Size)
                //.WhereIf(!string.IsNullOrEmpty(filterDTO.Color), p => p.Color == filterDTO.Color)
                .ToListAsync();

            return filteredProducts;
        }
    }
}
