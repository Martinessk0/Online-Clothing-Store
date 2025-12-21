using ClothingStore.Core.Models.Product;
using ClothingStore.Core.Services;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.UnitTests.Products
{
    public class ProductServiceTests
    {
        private static AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        private static ProductService CreateService(AppDbContext context)
        {
            var repo = new Repository(context);
            return new ProductService(repo);
        }

        private static void SeedBaseData(AppDbContext context)
        {
            context.Categories.Add(new Category { Id = 1, Name = "Shirts" });
            context.Set<Color>().Add(new Color { Id = 1, Name = "Черен", Hex = "#000" });
            context.SaveChanges();
        }

        [Fact]
        public async Task CreateProductAsync_ShouldCreateProduct_WhenDataIsValid()
        {
            using var context = CreateDbContext();
            SeedBaseData(context);

            var service = CreateService(context);

            var dto = new ProductCreateDTO
            {
                Name = "T-Shirt",
                Description = "Cotton",
                Brand = "Nike",
                Price = 50,
                CategoryId = 1,
                Variants =
            {
                new ProductVariantCreateDTO { ColorId = 1, Size = "M", Stock = 5 }
            },
                Images =
            {
                new ProductImageCreateDto { Url = "img.jpg", IsMain = true }
            }
            };

            var result = await service.CreateProductAsync(dto);

            result.Id.Should().BeGreaterThan(0);
            result.Variants.Should().HaveCount(1);
            result.Images.Should().HaveCount(1);
            result.IsActive.Should().BeTrue();
        }

        [Fact]
        public async Task CreateProductAsync_ShouldThrow_WhenCategoryMissing()
        {
            using var context = CreateDbContext();
            var service = CreateService(context);

            var dto = new ProductCreateDTO { CategoryId = 99 };

            await Assert.ThrowsAsync<ArgumentException>(
                () => service.CreateProductAsync(dto));
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldThrow_WhenDtoIsNull()
        {
            using var context = CreateDbContext();
            var service = CreateService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => service.UpdateProductAsync(1, null!));
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldUpdateProductAndImages()
        {
            using var context = CreateDbContext();
            SeedBaseData(context);

            var product = new Product
            {
                Id = 1,
                Name = "Old",
                CategoryId = 1,
                IsActive = true
            };

            context.Products.Add(product);
            context.SaveChanges();

            var service = CreateService(context);

            var dto = new ProductUpdateDTO
            {
                Name = "Updated",
                Description = "New Desc",
                Brand = "Adidas",
                Price = 80,
                CategoryId = 1,
                Images =
            {
                new ProductImageCreateDto { Url = "new.jpg", IsMain = true }
            }
            };

            await service.UpdateProductAsync(1, dto);

            var updated = await context.Products.Include(p => p.Images).FirstAsync();

            updated.Name.Should().Be("Updated");
            updated.Images.Should().HaveCount(1);
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldSoftDeleteProduct()
        {
            using var context = CreateDbContext();

            var product = new Product { Id = 1, IsActive = true };
            context.Products.Add(product);
            context.SaveChanges();

            var service = CreateService(context);

            var result = await service.DeleteProductAsync(1);

            result.Should().BeTrue();
            context.Products.First().IsActive.Should().BeFalse();
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldThrow_WhenNotFound()
        {
            using var context = CreateDbContext();
            var service = CreateService(context);

            await Assert.ThrowsAsync<ArgumentException>(
                () => service.DeleteProductAsync(1));
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnOnlyActiveProducts()
        {
            using var context = CreateDbContext();

            context.Products.AddRange(
                new Product { Id = 1, IsActive = true },
                new Product { Id = 2, IsActive = false }
            );

            context.SaveChanges();

            var service = CreateService(context);

            var result = await service.GetAllAsync();

            result.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenInactive()
        {
            using var context = CreateDbContext();

            context.Products.Add(new Product { Id = 1, IsActive = false });
            context.SaveChanges();

            var service = CreateService(context);

            var result = await service.GetByIdAsync(1);

            result.Should().BeNull();
        }
    }


}

