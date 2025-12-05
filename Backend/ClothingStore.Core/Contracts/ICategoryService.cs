using ClothingStore.Core.Models.Store;

namespace ClothingStore.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CategoryCreateDto model);
        Task UpdateAsync(int id, CategoryUpdateDto model);
        Task DeleteAsync(int id);
    }
}
