using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Store;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    // ТУК → entity-то има ParentId (малко d)
                    ParentID = c.ParentId,
                    IsActive = c.IsActive
                })
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var c = await _context.Categories.FindAsync(id);
            if (c == null) return null;

            return new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentID = c.ParentId,
                IsActive = c.IsActive
            };
        }

        public async Task<int> CreateAsync(CategoryCreateDto model)
        {
            var entity = new Category
            {
                Name = model.Name,
                ParentId = model.ParentID,
                IsActive = true
            };

            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(int id, CategoryUpdateDto model)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Category {id} not found");
            }

            entity.Name = model.Name;
            entity.ParentId = model.ParentID;
            entity.IsActive = model.IsActive;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null)
            {
                return;
            }

            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
