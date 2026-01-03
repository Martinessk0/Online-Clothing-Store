using ClothingStore.Core.Models.ProductReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Contracts
{
    public interface IProductReviewService
    {
        Task CreateAsync(CreateReviewDto dto, string userId);
        Task UpdateAsync(int reviewId, UpdateReviewDto dto, string userId);
        Task<IEnumerable<ReviewDto>> GetByProductAsync(int productId);

        Task SetVisibilityAsync(int reviewId, bool isVisible); // Admin
    }
}
