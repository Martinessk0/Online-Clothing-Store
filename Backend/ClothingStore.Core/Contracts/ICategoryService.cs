using ClothingStore.Core.Models.Category;
using ClothingStore.Infrastructure.Data.Entities;

namespace ClothingStore.Core.Contracts
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllCategories();

        public Task<Category> CreateCategory(CategoryCreateDto model);

        Task<Category> EditCategory(int id, CategoryCreateDto model);

        Task<bool> DeleteCategory(int id);
    }
}
