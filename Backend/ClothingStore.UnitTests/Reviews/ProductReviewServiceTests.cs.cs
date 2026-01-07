using ClothingStore.Core.Models.ProductReview;
using ClothingStore.Core.Services;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ClothingStore.UnitTests.Reviews
{
    public class ProductReviewServiceTests
    {
        private static AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        private static ProductReviewService CreateService(AppDbContext context)
        {
            var repo = new Repository(context);
            return new ProductReviewService(repo);
        }

        private static void SeedProduct(AppDbContext context)
        {
            context.Products.Add(new Product
            {
                Id = 1,
                Name = "T-Shirt",
                IsActive = true
            });

            context.SaveChanges();
        }

        private static void SeedCompletedOrder(
            AppDbContext context,
            string userId,
            int productId)
        {
            var order = new Order
            {
                UserId = userId,
                Status = OrderStatus.Completed
            };

            order.Items.Add(new OrderItem
            {
                ProductId = productId,
                Quantity = 1
            });

            context.Orders.Add(order);
            context.SaveChanges();
        }

        [Fact]
        public async Task CreateReviewAsync_ShouldCreateReview_WhenDataIsValid()
        {
            using var context = CreateDbContext();
            SeedProduct(context);
            SeedCompletedOrder(context, "user1", 1);

            var service = CreateService(context);

            var dto = new CreateReviewDto
            {
                ProductId = 1,
                Rating = 5,
                Comment = "Great product"
            };

            await service.CreateReviewAsync(dto, "user1");

            var review = context.ProductReviews.First();

            review.Rating.Should().Be(5);
            review.Comment.Should().Be("Great product");
            review.IsVisible.Should().BeTrue();
        }

        [Fact]
        public async Task CreateReviewAsync_ShouldThrow_WhenProductDoesNotExist()
        {
            using var context = CreateDbContext();
            var service = CreateService(context);

            var dto = new CreateReviewDto
            {
                ProductId = 99,
                Rating = 5
            };

            await Assert.ThrowsAsync<ArgumentException>(
                () => service.CreateReviewAsync(dto, "user1"));
        }

        [Fact]
        public async Task CreateReviewAsync_ShouldThrow_WhenUserHasNotPurchased()
        {
            using var context = CreateDbContext();
            SeedProduct(context);

            var service = CreateService(context);

            var dto = new CreateReviewDto
            {
                ProductId = 1,
                Rating = 4
            };

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.CreateReviewAsync(dto, "user1"));
        }

        [Fact]
        public async Task CreateReviewAsync_ShouldThrow_WhenAlreadyReviewed()
        {
            using var context = CreateDbContext();
            SeedProduct(context);
            SeedCompletedOrder(context, "user1", 1);

            context.ProductReviews.Add(new ProductReview
            {
                ProductId = 1,
                UserId = "user1",
                Rating = 5,
                IsVisible = true
            });

            context.SaveChanges();

            var service = CreateService(context);

            var dto = new CreateReviewDto
            {
                ProductId = 1,
                Rating = 3
            };

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.CreateReviewAsync(dto, "user1"));
        }

        [Fact]
        public async Task UpdateReviewAsync_ShouldUpdateReview_WhenOwner()
        {
            using var context = CreateDbContext();

            context.ProductReviews.Add(new ProductReview
            {
                Id = 1,
                ProductId = 1,
                UserId = "user1",
                Rating = 3,
                IsVisible = true
            });

            context.SaveChanges();

            var service = CreateService(context);

            var dto = new UpdateReviewDto
            {
                Rating = 5,
                Comment = "Updated"
            };

            await service.UpdateReviewAsync(1, dto, "user1");

            var review = context.ProductReviews.First();

            review.Rating.Should().Be(5);
            review.Comment.Should().Be("Updated");
            review.UpdatedAt.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateReviewAsync_ShouldThrow_WhenNotOwner()
        {
            using var context = CreateDbContext();

            context.ProductReviews.Add(new ProductReview
            {
                Id = 1,
                ProductId = 1,
                UserId = "user1",
                Rating = 3
            });

            context.SaveChanges();

            var service = CreateService(context);

            var dto = new UpdateReviewDto
            {
                Rating = 4
            };

            await Assert.ThrowsAsync<UnauthorizedAccessException>(
                () => service.UpdateReviewAsync(1, dto, "user2"));
        }

        [Fact]
        public async Task GetByProductAsync_ShouldReturnOnlyVisibleReviews_ByDefault()
        {
            using var context = CreateDbContext();
            SeedProduct(context);

            context.ProductReviews.AddRange(
                new ProductReview
                {
                    ProductId = 1,
                    Rating = 5,
                    IsVisible = true,
                    User = new ApplicationUser { UserName = "user1" }
                },
                new ProductReview
                {
                    ProductId = 1,
                    Rating = 1,
                    IsVisible = false,
                    User = new ApplicationUser { UserName = "user2" }
                }
            );

            context.SaveChanges();

            var service = CreateService(context);

            var result = await service.GetByProductAsync(1);

            result.Should().HaveCount(1);
        }

        [Fact]
        public async Task SetVisibilityAsync_ShouldUpdateVisibility()
        {
            using var context = CreateDbContext();

            context.ProductReviews.Add(new ProductReview
            {
                Id = 1,
                ProductId = 1,
                UserId = "user1",
                Rating = 4,
                IsVisible = true
            });

            context.Products.Add(new Product { Id = 1, IsActive = true });

            context.SaveChanges();

            var service = CreateService(context);

            await service.SetVisibilityAsync(1, false);

            context.ProductReviews.First().IsVisible.Should().BeFalse();
        }

        [Fact]
        public async Task CanReviewAsync_ShouldReturnTrue_WhenPurchasedAndNotReviewed()
        {
            using var context = CreateDbContext();
            SeedProduct(context);
            SeedCompletedOrder(context, "user1", 1);

            var service = CreateService(context);

            var result = await service.CanReviewAsync(1, "user1");

            result.Should().BeTrue();
        }

        [Fact]
        public async Task CanReviewAsync_ShouldReturnFalse_WhenAlreadyReviewed()
        {
            using var context = CreateDbContext();
            SeedProduct(context);
            SeedCompletedOrder(context, "user1", 1);

            context.ProductReviews.Add(new ProductReview
            {
                ProductId = 1,
                UserId = "user1",
                Rating = 5
            });

            context.SaveChanges();

            var service = CreateService(context);

            var result = await service.CanReviewAsync(1, "user1");

            result.Should().BeFalse();
        }
    }
}
