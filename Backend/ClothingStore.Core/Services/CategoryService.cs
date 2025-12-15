using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Category;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;

        public CategoryService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Category> CreateCategory(CategoryCreateDto model)
        {
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description,
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();

            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await repo.GetByIdAsync<Category>(id);

            if (category == null || !category.IsActive)
            {
                return false;
            }

            category.IsActive = false;

            repo.Update(category);
            await repo.SaveChangesAsync();

            return true;
        }

        public async Task<Category> EditCategory(int id, CategoryCreateDto model)
        {
            var category = await repo.GetByIdAsync<Category>(id);

            if (category == null)
            {
                throw new ArgumentException($"Category not found {id}");
            }

            category.Name = model.Name;

            repo.Update(category);
            await repo.SaveChangesAsync();

            return category;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await repo.AllReadonly<Category>().Where(p => p.IsActive).Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
                Description= c.Description,
            }).ToListAsync();
        }
    }
}
