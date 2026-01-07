using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.ProductReview;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Core.Services
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IRepository repo;

        public ProductReviewService(IRepository repo)
        {
            this.repo = repo;
        }

        
        public async Task CreateReviewAsync(CreateReviewDto dto, string userId)
        {
            var productExists = await repo.AllReadonly<Product>()
                .AnyAsync(p => p.Id == dto.ProductId && p.IsActive);

            if (!productExists)
                throw new ArgumentException("Product not found.");

            var hasPurchased = await repo.AllReadonly<Order>()
                .Include(o => o.Items)
                .Where(o =>
                    o.UserId == userId &&
                    (o.Status == OrderStatus.Completed || o.Status == OrderStatus.Paid))
                .SelectMany(o => o.Items)
                .AnyAsync(i => i.ProductId == dto.ProductId);

            if (!hasPurchased)
                throw new InvalidOperationException("You can review only products from completed orders.");

            if (dto.Rating < 1 || dto.Rating > 5)
                throw new ArgumentOutOfRangeException(nameof(dto.Rating), "Rating must be between 1 and 5.");

            var existingReview = await repo.All<ProductReview>()
                .FirstOrDefaultAsync(r =>
                    r.ProductId == dto.ProductId &&
                    r.UserId == userId);

            if (existingReview != null)
                throw new InvalidOperationException("You have already left a review for this product.");

            var review = new ProductReview
            {
                ProductId = dto.ProductId,
                UserId = userId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow,
                IsVisible = true
            };

            await repo.AddAsync(review);
            await repo.SaveChangesAsync();

            await RecalculateProductRatingAsync(dto.ProductId);
        }

        public async Task UpdateReviewAsync(int reviewId, UpdateReviewDto dto, string userId)
        {
            var review = await repo.All<ProductReview>()
                .FirstOrDefaultAsync(r => r.Id == reviewId);

            if (review == null)
                throw new ArgumentException("Review not found.");

            if (review.UserId != userId)
                throw new UnauthorizedAccessException("Not your review.");

            if (dto.Rating < 1 || dto.Rating > 5)
                throw new ArgumentOutOfRangeException(nameof(dto.Rating), "Rating must be between 1 and 5.");

            review.Rating = dto.Rating;
            review.Comment = dto.Comment;
            review.UpdatedAt = DateTime.UtcNow;

            await repo.SaveChangesAsync();
            await RecalculateProductRatingAsync(review.ProductId);
        }

        public async Task<IEnumerable<ReviewDto>> GetByProductAsync(int productId, bool includeHidden = false)
        {
            var query = repo.AllReadonly<ProductReview>()
                .Where(r => r.ProductId == productId && r.Product.IsActive);

            if (!includeHidden)
                query = query.Where(r => r.IsVisible);

            return await query
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt,
                    UserId = r.UserId,
                    UserName = r.User!.UserName!,
                    IsVisible = r.IsVisible
                })
                .ToListAsync();
        }

        public async Task SetVisibilityAsync(int reviewId, bool isVisible)
        {
            var review = await repo.GetByIdAsync<ProductReview>(reviewId);
            if (review == null)
                throw new ArgumentException("Review not found.");

            review.IsVisible = isVisible;
            review.UpdatedAt = DateTime.UtcNow;

            await repo.SaveChangesAsync();

            await RecalculateProductRatingAsync(review.ProductId);
        }

        private async Task RecalculateProductRatingAsync(int productId)
        {
            var reviews = await repo.AllReadonly<ProductReview>()
                .Where(r => r.ProductId == productId && r.IsVisible)
                .ToListAsync();

            var product = await repo.GetByIdAsync<Product>(productId);
            if (product == null) return;

            product.ReviewCount = reviews.Count;
            product.AverageRating = reviews.Count == 0
                ? 0
                : Math.Round(reviews.Average(r => r.Rating), 2);

            await repo.SaveChangesAsync();
        }

        public async Task<bool> CanReviewAsync(int productId, string userId)
        {
            var hasPurchased = await repo.AllReadonly<Order>()
                .Where(o => o.UserId == userId &&
                            (o.Status == OrderStatus.Completed || o.Status == OrderStatus.Paid))
                .SelectMany(o => o.Items)
                .AnyAsync(i => i.ProductId == productId);

            if (!hasPurchased) return false;

            var hasReviewed = await repo.AllReadonly<ProductReview>()
                .AnyAsync(r => r.UserId == userId && r.ProductId == productId);

            return !hasReviewed;
        }
    }
}
