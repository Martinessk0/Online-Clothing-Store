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

            var existingVariants = await repo.All<ProductVariant>()
                   .Where(v => v.ProductId == id)
                   .ToListAsync();

            foreach (var oldVar in existingVariants)
            {
                repo.Delete(oldVar);
            }

            foreach (var v in productDTO.Variants)
            {
                await repo.AddAsync(new ProductVariant
                {
                    ProductId = id,
                    ColorId = v.ColorId,
                    Size = v.Size,
                    Stock = v.Stock,
                    IsActive = true
                });
            }


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
                .Include(p => p.Variants.Where(v => v.IsActive))
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

        public async Task<List<Product>> FilterAsync(ProductFilterDTO filterDTO)
        {
            var query = repo.AllReadonly<Product>()
                .Where(p => p.IsActive)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Color)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filterDTO.Keyword))
            {
                var keyword = $"%{filterDTO.Keyword.Trim()}%";
                query = query.Where(p =>
                    EF.Functions.Like(p.Name, keyword) ||
                    EF.Functions.Like(p.Description, keyword) ||
                    EF.Functions.Like(p.Brand, keyword)
                );
            }

            // Price range
            query = query.WhereIf(filterDTO.MinPrice.HasValue, p => p.Price >= filterDTO.MinPrice.Value);
            query = query.WhereIf(filterDTO.MaxPrice.HasValue, p => p.Price <= filterDTO.MaxPrice.Value);

            // Brand filter
            query = query.WhereIf(!string.IsNullOrEmpty(filterDTO.Brand), p => p.Brand == filterDTO.Brand);

            // Stock filter
            query = query.WhereIf(filterDTO.InStockOnly.HasValue && filterDTO.InStockOnly.Value,
                p => p.Variants.Any(v => v.Stock > 0 && v.IsActive));

            // Size filter
            query = query.WhereIf(!string.IsNullOrEmpty(filterDTO.Size),
                p => p.Variants.Any(v => v.Size == filterDTO.Size && v.IsActive));

            // Color filter
            query = query.WhereIf(!string.IsNullOrEmpty(filterDTO.Color),
                p => p.Variants.Any(v => v.Color.Name == filterDTO.Color && v.IsActive));

            // Sorting
            if (!string.IsNullOrEmpty(filterDTO.SortBy))
            {
                switch (filterDTO.SortBy)
                {
                    case "PriceAsc":
                        query = query.OrderBy(p => p.Price);
                        break;
                    case "PriceDesc":
                        query = query.OrderByDescending(p => p.Price);
                        break;
                    case "Newest":
                        query = query.OrderByDescending(p => p.CreatedAt);
                        break;
                    case "Oldest":
                        query = query.OrderBy(p => p.CreatedAt);
                        break;
                    default:
                        query = query.OrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                query = query.OrderBy(p => p.Name);
            }

            return await query.ToListAsync();
        }
    }
}
