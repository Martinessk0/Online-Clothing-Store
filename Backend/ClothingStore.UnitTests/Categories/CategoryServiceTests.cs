using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingStore.Core.Services;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using ClothingStore.Core.Models.Category;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ClothingStore.UnitTests.Categories
{
    public class CategoryServiceTests
    {
        private static AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        private static CategoryService CreateService(AppDbContext context)
        {
            IRepository repo = new Repository(context);
            return new CategoryService(repo);
        }

        [Fact]
        public async Task CreateCategory_ShouldPersistAndReturnCategory()
        {
            using var context = CreateDbContext();
            var service = CreateService(context);

            var dto = new CategoryCreateDto
            {
                Name = "Shoes",
                Description = "Footwear"
            };

            var created = await service.CreateCategory(dto);

            created.Id.Should().BeGreaterThan(0);
            created.Name.Should().Be("Shoes");
            created.Description.Should().Be("Footwear");

            var dbCategory = await context.Categories.FirstOrDefaultAsync(c => c.Id == created.Id);
            dbCategory.Should().NotBeNull();
            dbCategory!.Name.Should().Be("Shoes");
            dbCategory.Description.Should().Be("Footwear");
            dbCategory.IsActive.Should().BeTrue(); // default in entity
        }

        [Fact]
        public async Task DeleteCategory_ShouldReturnFalse_WhenNotFound()
        {
            using var context = CreateDbContext();
            var service = CreateService(context);

            var result = await service.DeleteCategory(123);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task DeleteCategory_ShouldReturnFalse_WhenAlreadyInactive()
        {
            using var context = CreateDbContext();
            context.Categories.Add(new Category
            {
                Id = 1,
                Name = "Hats",
                Description = "Headwear",
                IsActive = false
            });
            await context.SaveChangesAsync();

            var service = CreateService(context);

            var result = await service.DeleteCategory(1);

            result.Should().BeFalse();

            var dbCategory = await context.Categories.FindAsync(1);
            dbCategory!.IsActive.Should().BeFalse();
        }

        [Fact]
        public async Task DeleteCategory_ShouldSoftDeleteAndReturnTrue_WhenActive()
        {
            using var context = CreateDbContext();
            context.Categories.Add(new Category
            {
                Id = 1,
                Name = "Hats",
                Description = "Headwear",
                IsActive = true
            });
            await context.SaveChangesAsync();

            var service = CreateService(context);

            var result = await service.DeleteCategory(1);

            result.Should().BeTrue();

            var dbCategory = await context.Categories.FindAsync(1);
            dbCategory.Should().NotBeNull();
            dbCategory!.IsActive.Should().BeFalse();
        }

        [Fact]
        public async Task EditCategory_ShouldThrow_WhenCategoryNotFound()
        {
            using var context = CreateDbContext();
            var service = CreateService(context);

            var dto = new CategoryCreateDto
            {
                Name = "Updated",
                Description = "Ignored by service"
            };

            Func<Task> act = async () => await service.EditCategory(42, dto);

            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Category not found 42");
        }

        [Fact]
        public async Task EditCategory_ShouldUpdateName_AndPersist()
        {
            using var context = CreateDbContext();
            context.Categories.Add(new Category
            {
                Id = 1,
                Name = "Old Name",
                Description = "Original description",
                IsActive = true
            });
            await context.SaveChangesAsync();

            var service = CreateService(context);

            var dto = new CategoryCreateDto
            {
                Name = "New Name",
                Description = "New description (service does not apply this)"
            };

            var edited = await service.EditCategory(1, dto);

            edited.Id.Should().Be(1);
            edited.Name.Should().Be("New Name");

            var dbCategory = await context.Categories.FindAsync(1);
            dbCategory!.Name.Should().Be("New Name");

            // Important: service only updates Name, not Description (assert to lock behavior)
            dbCategory.Description.Should().Be("Original description");
        }

        [Fact]
        public async Task GetAllCategories_ShouldReturnOnlyActiveCategories()
        {
            using var context = CreateDbContext();
            context.Categories.AddRange(
                new Category { Id = 1, Name = "Active 1", Description = "A1", IsActive = true },
                new Category { Id = 2, Name = "Inactive", Description = "I", IsActive = false },
                new Category { Id = 3, Name = "Active 2", Description = "A2", IsActive = true }
            );
            await context.SaveChangesAsync();

            var service = CreateService(context);

            var result = await service.GetAllCategories();

            result.Should().HaveCount(2);
            result.Select(r => r.Id).Should().BeEquivalentTo(new[] { 1, 3 });
            result.All(r => r.Name.StartsWith("Active")).Should().BeTrue();
        }
    }
}
