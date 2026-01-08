using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.PagedResults;
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
            if (productDTO == null)
            {
                throw new ArgumentNullException(nameof(productDTO));
            }

            productDTO.Variants ??= new List<ProductVariantCreateDTO>();
            productDTO.Images ??= new List<ProductImageCreateDto>();

            var product = await repo.All<Product>()
                .Include(p => p.Variants)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null || !product.IsActive)
            {
                throw new ArgumentException("Product not found");
            }

            var category = await repo.AllReadonly<Category>()
                .FirstOrDefaultAsync(c => c.Id == productDTO.CategoryId);

            if (category == null)
            {
                throw new ArgumentException($"Category not found {productDTO.CategoryId}");
            }

            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.Brand = productDTO.Brand;
            product.CategoryId = category.Id;
            product.ModifiedAt = DateTime.UtcNow;

            var existingVariants = product.Variants.ToList();
            var existingVariantIds = existingVariants.Select(v => v.Id).ToList();

            var variantIdsWithOrders = await repo.AllReadonly<OrderItem>()
                .Where(oi => oi.ProductVariantId != null &&
                             existingVariantIds.Contains(oi.ProductVariantId.Value))
                .Select(oi => oi.ProductVariantId!.Value)
                .Distinct()
                .ToListAsync();

            var variantsWithOrders = new HashSet<int>(variantIdsWithOrders);

            var usedExistingVariantIds = new HashSet<int>();

            foreach (var dto in productDTO.Variants.Where(v => v.Id > 0))
            {
                var existing = existingVariants.FirstOrDefault(v => v.Id == dto.Id);
                if (existing != null)
                {
                    existing.ColorId = dto.ColorId;
                    existing.Size = dto.Size;
                    existing.Stock = dto.Stock;
                    existing.IsActive = true;

                    usedExistingVariantIds.Add(existing.Id);
                }
            }

            foreach (var dto in productDTO.Variants)
            {
                if (dto.Id > 0 && usedExistingVariantIds.Contains(dto.Id))
                {
                    continue;
                }

                var existing = existingVariants.FirstOrDefault(v =>
                    !usedExistingVariantIds.Contains(v.Id) &&
                    v.ColorId == dto.ColorId &&
                    v.Size == dto.Size);

                if (existing != null)
                {
                    existing.Stock = dto.Stock;
                    existing.IsActive = true;

                    usedExistingVariantIds.Add(existing.Id);
                }
                else
                {
                    var newVariant = new ProductVariant
                    {
                        ProductId = id,
                        ColorId = dto.ColorId,
                        Size = dto.Size,
                        Stock = dto.Stock,
                        IsActive = true
                    };

                    await repo.AddAsync(newVariant);
                }
            }

            foreach (var existing in existingVariants)
            {
                if (usedExistingVariantIds.Contains(existing.Id))
                {
                    continue;
                }

                if (variantsWithOrders.Contains(existing.Id))
                {
                    existing.IsActive = false;
                }
                else
                {
                    repo.Delete(existing);
                }
            }

            var existingImages = product.Images.ToList();
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
                if (string.IsNullOrWhiteSpace(imgDto.Url))
                {
                    continue;
                }

                var newImage = new ProductImage
                {
                    ProductId = id,
                    Url = imgDto.Url,
                    PublicId = imgDto.PublicId ?? string.Empty,
                    IsMain = imgDto.IsMain,
                    SortOrder = sortOrder++
                };

                await repo.AddAsync(newImage);
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
                    AverageRating = p.AverageRating,   
                    ReviewCount = p.ReviewCount,
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

        public async Task<PagedResultDTO<ProductDTO>> FilterAsync(
            ProductFilterDTO filterDTO,
            int page,
            int pageSize)
        {
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 10 : pageSize;


            var query = repo.AllReadonly<Product>()
                .Where(p => p.IsActive)
                .Include(p => p.Images)
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


            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Brand = p.Brand,
                    CategoryId = p.CategoryId,
                    CreatedAt = p.CreatedAt,
                    Variants = p.Variants.Where(v => v.IsActive).Select(v => new ProductVariantDTO
                    {
                        Id = v.Id,
                        ColorId = v.ColorId,
                        ColorName = v.Color.Name,
                        ColorHex = v.Color.Hex,
                        Size = v.Size,
                        Stock = v.Stock
                    }).ToList(),
                    Images = p.Images
                        .OrderByDescending(i => i.IsMain)
                        .Select(i => new ProductImageDto
                        {
                            Id = i.Id,
                            Url = i.Url,
                            IsMain = i.IsMain
                        }).ToList()
                })
                .ToListAsync();

            return new PagedResultDTO<ProductDTO>
            {
                Items = items,
                TotalCount = totalCount
            };     
        }

        public async Task<ProductFilterOptionsDTO> GetFilterOptionsAsync()
        {
            var brands = await repo.AllReadonly<Product>()
                .Where(p => p.IsActive && p.Brand != null)
                .Select(p => p.Brand!)
                .Distinct()
                .OrderBy(b => b)
                .ToListAsync();

            var sizes = await repo.AllReadonly<ProductVariant>()
                .Where(v => v.IsActive)
                .Select(v => v.Size)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();

            var colors = await repo.AllReadonly<ProductVariant>()
                .Where(v => v.IsActive)
                .Select(v => v.Color.Name)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            return new ProductFilterOptionsDTO
            {
                Brands = brands,
                Sizes = sizes,
                Colors = colors
            };
        }
    }
}
