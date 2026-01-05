using ClothingStore.Core.Models.Recommendation;
using ClothingStore.Core.Services;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.UnitTests.Recommendations
{
    public class RecommendationServiceTests
    {
        private static AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        private static RecommendationService CreateService(AppDbContext context)
        {
            IRepository repo = new Repository(context);
            return new RecommendationService(repo);
        }

        private static async Task SeedCatalogAsync(AppDbContext context)
        {
            context.Set<Category>().AddRange(
                new Category { Id = 1, Name = "Cat1", Description = "C1", IsActive = true },
                new Category { Id = 2, Name = "Cat2", Description = "C2", IsActive = true }
            );

            context.Set<Color>().Add(new Color { Id = 1, Name = "Black", Hex = "#000", Code = "black" });

            // Products
            context.Set<Product>().AddRange(
                new Product
                {
                    Id = 10,
                    Name = "P10",
                    Description = "Desc",
                    Brand = "B1",
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    Variants = new List<ProductVariant>
                    {
                    new ProductVariant { Id = 100, ColorId = 1, Size = "M", Stock = 5, IsActive = true }
                    },
                    Images = new List<ProductImage>
                    {
                    new ProductImage { Id = 200, Url = "u10", IsMain = true, SortOrder = 0 }
                    }
                },
                new Product
                {
                    Id = 11,
                    Name = "P11",
                    Description = "Desc",
                    Brand = "B1",
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-20),
                    Variants = new List<ProductVariant>
                    {
                    new ProductVariant { Id = 101, ColorId = 1, Size = "M", Stock = 5, IsActive = true }
                    },
                    Images = new List<ProductImage>
                    {
                    new ProductImage { Id = 201, Url = "u11", IsMain = true, SortOrder = 0 }
                    }
                },
                new Product
                {
                    Id = 12,
                    Name = "P12",
                    Description = "Desc",
                    Brand = "B2",
                    CategoryId = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    Variants = new List<ProductVariant>
                    {
                    new ProductVariant { Id = 102, ColorId = 1, Size = "L", Stock = 5, IsActive = true }
                    },
                    Images = new List<ProductImage>
                    {
                    new ProductImage { Id = 202, Url = "u12", IsMain = true, SortOrder = 0 }
                    }
                },
                new Product
                {
                    Id = 13,
                    Name = "Inactive",
                    Description = "Desc",
                    Brand = "B2",
                    CategoryId = 2,
                    IsActive = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    Variants = new List<ProductVariant>
                    {
                    new ProductVariant { Id = 103, ColorId = 1, Size = "L", Stock = 5, IsActive = true }
                    },
                    Images = new List<ProductImage>
                    {
                    new ProductImage { Id = 203, Url = "u13", IsMain = true, SortOrder = 0 }
                    }
                }
            );

            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task TrackInteractionAsync_ShouldReturnEarly_WhenTypeIsEmptyOrWhitespace()
        {
            using var context = CreateDbContext();
            var service = CreateService(context);

            await service.TrackInteractionAsync("u1", new TrackInteractionDto { Type = "" });
            await service.TrackInteractionAsync("u1", new TrackInteractionDto { Type = "   " });

            (await context.Set<UserInteraction>().CountAsync()).Should().Be(0);
        }

        [Fact]
        public async Task TrackInteractionAsync_ShouldPersistInteraction_AndInferCategoryFromProduct_WhenCategoryMissing()
        {
            using var context = CreateDbContext();
            await SeedCatalogAsync(context);

            var service = CreateService(context);

            var dto = new TrackInteractionDto
            {
                ProductId = 10,
                CategoryId = null,            // should infer from Product.CategoryId
                AnonymousId = "anon-1",
                Type = "ProductView",
                DurationSeconds = 7,
                Payload = "x"
            };

            await service.TrackInteractionAsync(userId: null, dto);

            var saved = await context.Set<UserInteraction>().SingleAsync();
            saved.UserId.Should().BeNull();
            saved.AnonymousId.Should().Be("anon-1");
            saved.ProductId.Should().Be(10);
            saved.CategoryId.Should().Be(1); // inferred
            saved.DurationSeconds.Should().Be(7);
            saved.Payload.Should().Be("x");
        }

        [Theory]
        [InlineData("productview")]
        [InlineData("addtocart")]
        [InlineData("purchase")]
        [InlineData("categoryview")]
        [InlineData("search")]
        [InlineData("unknown")] // default branch => ProductView
        public async Task TrackInteractionAsync_ShouldParseType_AndPersist(string type)
        {
            using var context = CreateDbContext();
            await SeedCatalogAsync(context);

            var service = CreateService(context);

            var dto = new TrackInteractionDto
            {
                CategoryId = 2,
                Type = type
            };

            await service.TrackInteractionAsync("user-1", dto);

            var saved = await context.Set<UserInteraction>().SingleAsync();
            saved.UserId.Should().Be("user-1");
            saved.CategoryId.Should().Be(2);

            // Validate the enum mapping indirectly (stored enum value)
            // Unknown should default to ProductView.
            if (type == "addtocart") saved.Type.Should().Be(InteractionType.AddToCart);
            else if (type == "purchase") saved.Type.Should().Be(InteractionType.Purchase);
            else if (type == "categoryview") saved.Type.Should().Be(InteractionType.CategoryView);
            else if (type == "search") saved.Type.Should().Be(InteractionType.Search);
            else saved.Type.Should().Be(InteractionType.ProductView);
        }

        [Fact]
        public async Task GetRecommendationsAsync_ShouldReturnDefault_WhenNoUserAndNoAnonymous()
        {
            using var context = CreateDbContext();
            await SeedCatalogAsync(context);

            var service = CreateService(context);

            var result = await service.GetRecommendationsAsync(
                userId: null,
                anonymousId: null,
                currentCategoryId: null,
                take: 10);

            // Default: newest first then price, active only
            result.Should().NotBeNull();
            result.Should().NotContain(p => p.Name == "Inactive");
            result.Should().HaveCount(3);
        }

        [Fact]
        public async Task GetRecommendationsAsync_ShouldReturnDefault_WhenUserHasNoInteractions()
        {
            using var context = CreateDbContext();
            await SeedCatalogAsync(context);

            var service = CreateService(context);

            var result = await service.GetRecommendationsAsync(
                userId: "user-no-data",
                anonymousId: null,
                currentCategoryId: 1,
                take: 10);

            // Default filtered by category 1 => only products 10 and 11
            result.Select(r => r.Id).Should().BeEquivalentTo(new[] { 10, 11 });
        }

        [Fact]
        public async Task GetRecommendationsAsync_ShouldReturnDefault_WhenInteractionsHaveNoCategoryId()
        {
            using var context = CreateDbContext();
            await SeedCatalogAsync(context);

            // Interactions without CategoryId => categoryStats empty => default
            context.Set<UserInteraction>().Add(new UserInteraction
            {
                UserId = "u1",
                AnonymousId = null,
                ProductId = 10,
                CategoryId = null,
                Type = InteractionType.ProductView,
                CreatedAt = DateTime.UtcNow
            });
            await context.SaveChangesAsync();

            var service = CreateService(context);

            var result = await service.GetRecommendationsAsync(
                userId: "u1",
                anonymousId: null,
                currentCategoryId: 2,
                take: 10);

            // Default filtered by category 2 => only product 12
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(12);
        }

        [Fact]
        public async Task GetRecommendationsAsync_ShouldReturnEmpty_WhenCategoryFilterHasNoProducts()
        {
            using var context = CreateDbContext();
            await SeedCatalogAsync(context);

            // Make interactions so it does not fall back to default before product query
            context.Set<UserInteraction>().Add(new UserInteraction
            {
                UserId = "u1",
                CategoryId = 1,
                Type = InteractionType.ProductView,
                CreatedAt = DateTime.UtcNow,
                DurationSeconds = 1
            });
            await context.SaveChangesAsync();

            var service = CreateService(context);

            // Category 999 doesn't exist in products => empty
            var result = await service.GetRecommendationsAsync(
                userId: "u1",
                anonymousId: null,
                currentCategoryId: 999,
                take: 10);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetRecommendationsAsync_ShouldPreferPreferredCategory_AndRespectTake()
        {
            using var context = CreateDbContext();
            await SeedCatalogAsync(context);

            // Interactions strongly favor category 1
            context.Set<UserInteraction>().AddRange(
                new UserInteraction
                {
                    UserId = "u1",
                    CategoryId = 1,
                    Type = InteractionType.ProductView,
                    CreatedAt = DateTime.UtcNow,
                    DurationSeconds = 0
                },
                new UserInteraction
                {
                    UserId = "u1",
                    CategoryId = 1,
                    Type = InteractionType.AddToCart,
                    CreatedAt = DateTime.UtcNow,
                    DurationSeconds = 0
                },
                new UserInteraction
                {
                    UserId = "u1",
                    CategoryId = 2,
                    Type = InteractionType.ProductView,
                    CreatedAt = DateTime.UtcNow,
                    DurationSeconds = 0
                }
            );

            // popularity via OrderItems boosts product 12, but preference should still help cat 1 products
            context.Set<OrderItem>().Add(new OrderItem
            {
                Id = 1,
                ProductId = 12,
                Quantity = 100
            });

            await context.SaveChangesAsync();

            var service = CreateService(context);

            var result = await service.GetRecommendationsAsync(
                userId: "u1",
                anonymousId: null,
                currentCategoryId: null,
                take: 2);

            result.Should().HaveCount(2);
            result.Should().OnlyContain(p => p.Id == 10 || p.Id == 11 || p.Id == 12);

            // Because category preference is strongly in favor of category 1,
            // we expect at least one of cat1 products (10 or 11) in top 2.
            result.Select(r => r.CategoryId).Should().Contain(1);
        }

        [Fact]
        public async Task GetRecommendationsAsync_ShouldUseAnonymousId_WhenUserIdMissing()
        {
            using var context = CreateDbContext();
            await SeedCatalogAsync(context);

            context.Set<UserInteraction>().Add(new UserInteraction
            {
                AnonymousId = "anon-1",
                CategoryId = 2,
                Type = InteractionType.CategoryView,
                DurationSeconds = 5,
                CreatedAt = DateTime.UtcNow
            });
            await context.SaveChangesAsync();

            var service = CreateService(context);

            var result = await service.GetRecommendationsAsync(
                userId: null,
                anonymousId: "anon-1",
                currentCategoryId: 2,
                take: 10);

            // Filter by category 2 => product 12 only
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(12);
        }
    }
}
