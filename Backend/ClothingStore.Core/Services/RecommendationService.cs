using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Product;
using ClothingStore.Core.Models.Recommendation;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Core.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRepository repo;

        public RecommendationService(IRepository repo)
        {
            this.repo = repo;
        }


        public async Task TrackInteractionAsync(string? userId, TrackInteractionDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Type))
            {
                return;
            }

            var type = ParseType(dto.Type);

            int? categoryId = dto.CategoryId;

            if (!categoryId.HasValue && dto.ProductId.HasValue)
            {
                var productCat = await repo.AllReadonly<Product>()
                    .Where(p => p.Id == dto.ProductId.Value)
                    .Select(p => new { p.CategoryId })
                    .FirstOrDefaultAsync();

                if (productCat != null)
                {
                    categoryId = productCat.CategoryId;
                }
            }

            var interaction = new UserInteraction
            {
                UserId = userId,
                AnonymousId = dto.AnonymousId,
                ProductId = dto.ProductId,
                CategoryId = categoryId,
                Type = type,
                DurationSeconds = dto.DurationSeconds,
                Payload = dto.Payload,
                CreatedAt = DateTime.UtcNow
            };

            await repo.AddAsync(interaction);
            await repo.SaveChangesAsync();
        }

        private static InteractionType ParseType(string type)
        {
            switch (type.Trim().ToLowerInvariant())
            {
                case "productview": return InteractionType.ProductView;
                case "addtocart": return InteractionType.AddToCart;
                case "purchase": return InteractionType.Purchase;
                case "categoryview": return InteractionType.CategoryView;
                case "search": return InteractionType.Search;
                default: return InteractionType.ProductView;
            }
        }


        public async Task<IReadOnlyList<ProductDTO>> GetRecommendationsAsync(
            string? userId,
            string? anonymousId,
            int? currentCategoryId,
            int take = 4)
        {
            var cutoff = DateTime.UtcNow.AddDays(-60);

            var interactionsQuery = repo.AllReadonly<UserInteraction>()
                .Where(i => i.CreatedAt >= cutoff);

            if (!string.IsNullOrEmpty(userId))
            {
                interactionsQuery = interactionsQuery.Where(i => i.UserId == userId);
            }
            else if (!string.IsNullOrEmpty(anonymousId))
            {
                interactionsQuery = interactionsQuery.Where(i => i.AnonymousId == anonymousId);
            }
            else
            {
                return await GetDefaultRecommendationsAsync(currentCategoryId, take);
            }

            var interactions = await interactionsQuery.ToListAsync();
            if (!interactions.Any())
            {
                return await GetDefaultRecommendationsAsync(currentCategoryId, take);
            }

            // Статистика по категории
            var categoryStats = interactions
                .Where(i => i.CategoryId.HasValue)
                .GroupBy(i => i.CategoryId!.Value)
                .Select(g => new
                {
                    CategoryId = g.Key,
                    Seconds = g.Where(i => i.Type == InteractionType.CategoryView)
                               .Sum(i => i.DurationSeconds ?? 0),
                    Views = g.Count(i => i.Type == InteractionType.ProductView),
                    Adds = g.Count(i => i.Type == InteractionType.AddToCart),
                    Purchases = g.Count(i => i.Type == InteractionType.Purchase)
                })
                .ToList();

            if (!categoryStats.Any())
            {
                return await GetDefaultRecommendationsAsync(currentCategoryId, take);
            }

            var catScore = new Dictionary<int, double>();

            foreach (var stat in categoryStats)
            {
                double score =
                    1.0 * stat.Views +
                    10.0 * stat.Seconds +
                    30.0 * stat.Adds +
                    50.0 * stat.Purchases;

                catScore[stat.CategoryId] = score;
            }

            var maxScore = catScore.Values.Max();
            if (maxScore <= 0)
            {
                return await GetDefaultRecommendationsAsync(currentCategoryId, take);
            }

            var catPreference = catScore
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value / maxScore);

            var popularityDict = await repo.AllReadonly<OrderItem>()
                .GroupBy(oi => oi.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    SoldQuantity = g.Sum(oi => oi.Quantity)
                })
                .ToDictionaryAsync(x => x.ProductId, x => x.SoldQuantity);

            double maxPop = popularityDict.Any() ? popularityDict.Values.Max() : 0.0;

            IQueryable<Product> productsQuery = repo.AllReadonly<Product>()
                .Where(p => p.IsActive)
                .Include(p => p.Images)
                .Include(p => p.Variants.Where(v => v.IsActive))
                    .ThenInclude(v => v.Color);

            if (currentCategoryId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.CategoryId == currentCategoryId.Value);
            }

            var products = await productsQuery.ToListAsync();
            if (!products.Any())
            {
                return Array.Empty<ProductDTO>();
            }

            var now = DateTime.UtcNow;

            var scored = products
                .Select(p =>
                {
                    double catPref = catPreference.TryGetValue(p.CategoryId, out var cp)
                        ? cp
                        : 0.0;

                    double popScore = 0.0;
                    if (maxPop > 0 &&
                        popularityDict.TryGetValue(p.Id, out var sold))
                    {
                        popScore = (double)sold / maxPop;
                    }

                    var days = (now - p.CreatedAt).TotalDays;
                    double freshness = days <= 30
                        ? Math.Max(0.0, 1.0 - (days / 30.0))
                        : 0.0;

                    double categoryBoost = 0.0;
                    if (currentCategoryId.HasValue && p.CategoryId == currentCategoryId.Value)
                    {
                        categoryBoost = 0.1;
                    }

                    double finalScore =
                        0.6 * catPref +
                        0.3 * popScore +
                        0.1 * freshness +
                        categoryBoost;

                    return new { Product = p, Score = finalScore };
                })
                .OrderByDescending(x => x.Score)
                .ThenByDescending(x => x.Product.CreatedAt)
                .Take(take)
                .ToList();

            return scored.Select(x => MapToDto(x.Product)).ToList();
        }

        private async Task<IReadOnlyList<ProductDTO>> GetDefaultRecommendationsAsync(
            int? currentCategoryId,
            int take)
        {
            IQueryable<Product> productsQuery = repo.AllReadonly<Product>()
                .Where(p => p.IsActive)
                .Include(p => p.Images)
                .Include(p => p.Variants.Where(v => v.IsActive))
                    .ThenInclude(v => v.Color);

            if (currentCategoryId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.CategoryId == currentCategoryId.Value);
            }

            var products = await productsQuery
                .OrderByDescending(p => p.CreatedAt)
                .ThenBy(p => p.Price)
                .Take(take)
                .ToListAsync();

            return products.Select(MapToDto).ToList();
        }

        private static ProductDTO MapToDto(Product p)
        {
            return new ProductDTO
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
            };
        }
    }
}
