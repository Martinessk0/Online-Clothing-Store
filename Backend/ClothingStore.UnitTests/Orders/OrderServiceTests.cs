using ClothingStore.Core.Models.Order;
using ClothingStore.Core.Services;
using ClothingStore.Core.Contracts;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ClothingStore.UnitTests.Orders
{
    public class OrderServiceTests
    {
        private readonly IRepository repo;
        private readonly AppDbContext context;
        private readonly Mock<ISpeedyService> speedyMock;
        private readonly OrderService service;

        public OrderServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new AppDbContext(options);
            repo = new Repository(context);

            speedyMock = new Mock<ISpeedyService>();
            service = new OrderService(repo, speedyMock.Object);
        }

        // -------------------------
        // CREATE ORDER
        // -------------------------

        [Fact]
        public async Task CreateOrderAsync_EmptyItems_ShouldThrow()
        {
            var dto = new OrderCreateDto
            {
                PaymentMethod = PaymentMethod.CashOnDelivery,
                Items = new List<OrderCreateItemDto>()
            };

            Func<Task> act = async () =>
                await service.CreateOrderAsync(dto, null);

            await act.Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Order must contain at least one item.");
        }

        [Fact]
        public async Task CreateOrderAsync_InvalidPaymentMethod_ShouldThrow()
        {
            var dto = new OrderCreateDto
            {
                PaymentMethod = (PaymentMethod)99,
                Items = new List<OrderCreateItemDto>
                {
                    new OrderCreateItemDto { ProductId = 1, Quantity = 1 }
                }
            };

            Func<Task> act = async () =>
                await service.CreateOrderAsync(dto, null);

            await act.Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Невалиден метод на плащане.");
        }

        [Fact]
        public async Task CreateOrderAsync_ProductNotActive_ShouldThrow()
        {
            context.Add(new Product
            {
                Id = 1,
                Price = 50,
                IsActive = false
            });
            await context.SaveChangesAsync();

            var dto = new OrderCreateDto
            {
                PaymentMethod = PaymentMethod.CashOnDelivery,
                Items = new List<OrderCreateItemDto>
                {
                    new OrderCreateItemDto { ProductId = 1, Quantity = 1 }
                }
            };

            Func<Task> act = async () =>
                await service.CreateOrderAsync(dto, null);

            await act.Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("One or more products are not available.");
        }

        [Fact]
        public async Task CreateOrderAsync_NotEnoughVariantStock_ShouldThrow()
        {
            var color = new Color
            {
                Id = 1,
                Name = "Red",
                Code = "red"
            };

            var product = new Product
            {
                Id = 1,
                Price = 40,
                IsActive = true
            };

            var variant = new ProductVariant
            {
                Id = 10,
                ProductId = product.Id,
                Product = product,
                ColorId = color.Id,
                Color = color,
                Stock = 1,
                IsActive = true,
                Size = "M"
            };

            context.Add(color);
            context.Add(product);
            context.Add(variant);
            await context.SaveChangesAsync();

            var dto = new OrderCreateDto
            {
                PaymentMethod = PaymentMethod.CashOnDelivery,
                Items = new List<OrderCreateItemDto>
        {
            new OrderCreateItemDto
            {
                ProductId = product.Id,
                ProductVariantId = variant.Id,
                Quantity = 2 
            }
        }
            };

            Func<Task> act = async () => await service.CreateOrderAsync(dto, null);

            await act.Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Not enough stock for selected variant.");
        }


        [Fact]
        public async Task CreateOrderAsync_ValidData_ShouldCreateOrder()
        {
            var product = new Product
            {
                Id = 1,
                Price = 25,
                IsActive = true
            };

            context.Add(product);
            await context.SaveChangesAsync();

            var dto = new OrderCreateDto
            {
                CustomerName = "Test User",
                Email = "test@test.com",
                Phone = "123456",
                Address = "Test Address",
                PaymentMethod = PaymentMethod.CashOnDelivery,
                Items = new List<OrderCreateItemDto>
                {
                    new OrderCreateItemDto
                    {
                        ProductId = 1,
                        Quantity = 2
                    }
                }
            };

            var orderId = await service.CreateOrderAsync(dto, "user-1");

            var order = await repo.GetByIdAsync<Order>(orderId);

            order.Should().NotBeNull();
            order!.UserId.Should().Be("user-1");
            order.TotalAmount.Should().Be(50);
            order.Status.Should().Be(OrderStatus.Pending);
            order.Items.Count.Should().Be(1);
        }

        // -------------------------
        // UPDATE STATUS
        // -------------------------

        [Fact]
        public async Task UpdateOrderStatusAsync_OrderNotFound_ShouldReturnFalse()
        {
            var result = await service.UpdateOrderStatusAsync(999, "Completed");

            result.Should().BeFalse();
        }

        [Fact]
        public async Task UpdateOrderStatusAsync_InvalidStatus_ShouldReturnFalse()
        {
            var order = new Order { Status = OrderStatus.Pending };
            context.Add(order);
            await context.SaveChangesAsync();

            var result = await service.UpdateOrderStatusAsync(order.Id, "InvalidStatus");

            result.Should().BeFalse();
        }

        [Fact]
        public async Task UpdateOrderStatusAsync_PaidOrder_ShouldNotChangeStatus()
        {
            var order = new Order { Status = OrderStatus.Paid };
            context.Add(order);
            await context.SaveChangesAsync();

            var result = await service.UpdateOrderStatusAsync(order.Id, "Cancelled");

            result.Should().BeFalse();
        }

        [Fact]
        public async Task UpdateOrderStatusAsync_ValidStatus_ShouldUpdate()
        {
            var order = new Order { Status = OrderStatus.Pending };
            context.Add(order);
            await context.SaveChangesAsync();

            var result = await service.UpdateOrderStatusAsync(order.Id, "Completed");

            result.Should().BeTrue();

            var updated = await repo.GetByIdAsync<Order>(order.Id);
            updated!.Status.Should().Be(OrderStatus.Completed);
        }
    }
}
