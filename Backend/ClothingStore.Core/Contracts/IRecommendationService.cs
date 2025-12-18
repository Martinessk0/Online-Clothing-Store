using ClothingStore.Core.Models.Product;
using ClothingStore.Core.Models.Recommendation;

namespace ClothingStore.Core.Contracts
{
    public interface IRecommendationService
    {
        Task TrackInteractionAsync(string? userId, TrackInteractionDto dto);

        Task<IReadOnlyList<ProductDTO>> GetRecommendationsAsync(
            string? userId,
            string? anonymousId,
            int? categoryId,
            int take = 4);
    }
}
