using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.ProductReview;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class ProductReviewService : IProductReviewService
{
    private readonly IRepository repo;

    public ProductReviewService(IRepository repo)
    {
        this.repo = repo;
    }

    // ---------------------------
    // CREATE
    // ---------------------------
    public async Task CreateAsync(CreateReviewDto dto, string userId)
    {
        // 1. Product exists
        var productExists = await repo.AllReadonly<Product>()
            .AnyAsync(p => p.Id == dto.ProductId && p.IsActive);

        if (!productExists)
            throw new ArgumentException("Product not found.");

        // 2. User has purchased product (PAID or COMPLETED)
        var hasPurchased = await repo.AllReadonly<Order>()
            .Where(o =>
                o.UserId == userId &&
                (o.Status == OrderStatus.Paid || o.Status == OrderStatus.Completed))
            .SelectMany(o => o.Items)
            .AnyAsync(i => i.ProductId == dto.ProductId);

        if (!hasPurchased)
            throw new InvalidOperationException("You can review only purchased products.");

        // 3. One review per product per user (DB enforces this too)
        var alreadyReviewed = await repo.AllReadonly<ProductReview>()
            .AnyAsync(r => r.ProductId == dto.ProductId && r.UserId == userId);

        if (alreadyReviewed)
            throw new InvalidOperationException("You already reviewed this product.");

        if (dto.Rating < 1 || dto.Rating > 5)
            throw new ArgumentOutOfRangeException(nameof(dto.Rating), "Rating must be between 1 and 5.");


        var review = new ProductReview
        {
            ProductId = dto.ProductId,
            UserId = userId,
            Rating = dto.Rating,
            Comment = dto.Comment,
            CreatedAt = DateTime.UtcNow
        };

        await repo.AddAsync(review);
        await repo.SaveChangesAsync();

        await RecalculateProductRatingAsync(dto.ProductId);
    }

    // ---------------------------
    // UPDATE (owner only)
    // ---------------------------
    public async Task UpdateAsync(int reviewId, UpdateReviewDto dto, string userId)
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

    // ---------------------------
    // GET BY PRODUCT
    // ---------------------------
    public async Task<IEnumerable<ReviewDto>> GetByProductAsync(int productId)
    {
        return await repo.AllReadonly<ProductReview>()
            .Where(r => r.ProductId == productId && r.IsVisible && r.Product.IsActive)
            .Include(r => r.User)
            .OrderByDescending(r => r.CreatedAt)
            .Select(r => new ReviewDto
            {
                Id = r.Id,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt,
                UserId = r.UserId,
                UserName = r.User!.UserName!
            })
            .ToListAsync();
    }

    // ---------------------------
    // ADMIN: HIDE / UNHIDE
    // ---------------------------
    public async Task SetVisibilityAsync(int reviewId, bool isVisible)
    {
        var review = await repo.GetByIdAsync<ProductReview>(reviewId);
        if (review == null)
            throw new ArgumentException("Review not found.");

        review.IsVisible = isVisible;
        await RecalculateProductRatingAsync(review.ProductId);
    }

    // ---------------------------
    // RATING RECALCULATION
    // ---------------------------
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
}
