using ClothingStore.Core.Models.Store;

namespace ClothingStore.Core.Contracts
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetByProductAsync(int productId);

        Task<int> CreateAsync(ReviewCreateDto model);

        Task DeleteAsync(int id);
    }
}
