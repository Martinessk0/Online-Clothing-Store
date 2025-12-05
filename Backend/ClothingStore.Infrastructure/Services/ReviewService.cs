using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Store;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;

        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReviewDto>> GetByProductAsync(int productId)
        {
            return await _context.Reviews
                .Where(r => r.ProductID == productId)          // ProductID от ентитито
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new ReviewDto
                {
                    Id = r.ReviewID,                    // мапваме към DTO-то
                    ProductId = r.ProductID,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<int> CreateAsync(ReviewCreateDto model)
        {
            var entity = new Review
            {
                ProductID = model.ProductId,
                Rating = model.Rating,
                Comment = model.Comment ?? string.Empty,
                CreatedAt = DateTime.UtcNow
            };

            _context.Reviews.Add(entity);
            await _context.SaveChangesAsync();

            return entity.ReviewID;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Reviews.FindAsync(id);
            if (entity == null)
            {
                return;
            }

            _context.Reviews.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
