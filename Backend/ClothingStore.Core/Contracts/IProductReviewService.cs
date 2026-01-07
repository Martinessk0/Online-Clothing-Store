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
        Task CreateReviewAsync(CreateReviewDto dto, string userId);
        Task UpdateReviewAsync(int reviewId, UpdateReviewDto dto, string userId);
        Task<IEnumerable<ReviewDto>> GetByProductAsync(int productId, bool includeHidden = false);
        Task SetVisibilityAsync(int reviewId, bool isVisible);
        Task<bool> CanReviewAsync(int productId, string userId);
    }
}
