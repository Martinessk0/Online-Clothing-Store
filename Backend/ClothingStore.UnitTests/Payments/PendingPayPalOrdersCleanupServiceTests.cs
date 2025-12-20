using ClothingStore.Core.Models.Paypal;
using ClothingStore.Core.Services;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ClothingStore.UnitTests.Payments
{
    public class PendingPayPalOrdersCleanupServiceTests
    {
        private readonly AppDbContext context;
        private readonly IRepository repo;
        private readonly IServiceScopeFactory scopeFactory;

        public PendingPayPalOrdersCleanupServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new AppDbContext(options);
            repo = new Repository(context);

            var services = new ServiceCollection();
            services.AddSingleton<IRepository>(repo);
            var provider = services.BuildServiceProvider();

            var scope = new FakeServiceScope(provider);
            scopeFactory = new FakeScopeFactory(scope);
        }

        private async Task InvokeCleanup(PendingPayPalOrdersCleanupService service, TimeSpan expireAfter)
        {
            var method = typeof(PendingPayPalOrdersCleanupService)
                .GetMethod("CleanupOnce", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            await (Task)method.Invoke(service, new object[] { expireAfter, CancellationToken.None })!;
        }

        [Fact]
        public async Task ExpiredPayPalOrders_ShouldBeCancelled_AndStockRestored()
        {
            var variant = new ProductVariant { Id = 1, Stock = 5, Size = "M", ColorId = 1, ProductId = 1 };
            context.Add(variant);

            var order = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow.AddMinutes(-20),
                Items = new[] { new OrderItem { ProductVariantId = variant.Id, Quantity = 2, UnitPrice = 10, LineTotal = 20 } }
            };
            context.Add(order);
            await context.SaveChangesAsync();

            var optionsMonitor = new FakeOptionsMonitor<PayPalCleanupOptions>(
                new PayPalCleanupOptions { ExpireAfterMinutes = 10, TickSeconds = 1 });

            var service = new PendingPayPalOrdersCleanupService(scopeFactory, optionsMonitor);

            await InvokeCleanup(service, TimeSpan.FromMinutes(10));

            var updatedOrder = await repo.GetByIdAsync<Order>(order.Id);
            updatedOrder!.Status.Should().Be(OrderStatus.Cancelled);

            var updatedVariant = await repo.GetByIdAsync<ProductVariant>(variant.Id);
            updatedVariant!.Stock.Should().Be(7); // 5 + 2
        }

        [Fact]
        public async Task OrdersNotExpired_ShouldRemainUnchanged()
        {
            var variant = new ProductVariant { Id = 2, Stock = 10, Size = "L", ColorId = 1, ProductId = 1 };
            context.Add(variant);

            var order = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow, // не е изтекла
                Items = new[] { new OrderItem { ProductVariantId = variant.Id, Quantity = 3, UnitPrice = 15, LineTotal = 45 } }
            };
            context.Add(order);
            await context.SaveChangesAsync();

            var optionsMonitor = new FakeOptionsMonitor<PayPalCleanupOptions>(
                new PayPalCleanupOptions { ExpireAfterMinutes = 10, TickSeconds = 1 });

            var service = new PendingPayPalOrdersCleanupService(scopeFactory, optionsMonitor);

            await InvokeCleanup(service, TimeSpan.FromMinutes(10));

            var updatedOrder = await repo.GetByIdAsync<Order>(order.Id);
            updatedOrder!.Status.Should().Be(OrderStatus.Pending);

            var updatedVariant = await repo.GetByIdAsync<ProductVariant>(variant.Id);
            updatedVariant!.Stock.Should().Be(10);
        }

        [Fact]
        public async Task OrdersWithNonPayPalMethod_ShouldRemainUnchanged()
        {
            var variant = new ProductVariant { Id = 3, Stock = 2, Size = "S", ColorId = 1, ProductId = 1 };
            context.Add(variant);

            var order = new Order
            {
                PaymentMethod = PaymentMethod.CashOnDelivery,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow.AddMinutes(-20),
                Items = new[] { new OrderItem { ProductVariantId = variant.Id, Quantity = 1, UnitPrice = 10, LineTotal = 10 } }
            };
            context.Add(order);
            await context.SaveChangesAsync();

            var optionsMonitor = new FakeOptionsMonitor<PayPalCleanupOptions>(
                new PayPalCleanupOptions { ExpireAfterMinutes = 10, TickSeconds = 1 });

            var service = new PendingPayPalOrdersCleanupService(scopeFactory, optionsMonitor);

            await InvokeCleanup(service, TimeSpan.FromMinutes(10));

            var updatedOrder = await repo.GetByIdAsync<Order>(order.Id);
            updatedOrder!.Status.Should().Be(OrderStatus.Pending);

            var updatedVariant = await repo.GetByIdAsync<ProductVariant>(variant.Id);
            updatedVariant!.Stock.Should().Be(2);
        }

        [Fact]
        public async Task AlreadyCancelledOrPaidOrders_ShouldNotChange()
        {
            var variant = new ProductVariant { Id = 4, Stock = 0, Size = "XL", ColorId = 1, ProductId = 1 };
            context.Add(variant);

            var order1 = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                Status = OrderStatus.Cancelled,
                CreatedAt = DateTime.UtcNow.AddMinutes(-30),
                Items = new[] { new OrderItem { ProductVariantId = variant.Id, Quantity = 1, UnitPrice = 10, LineTotal = 10 } }
            };

            var order2 = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                Status = OrderStatus.Paid,
                CreatedAt = DateTime.UtcNow.AddMinutes(-30),
                Items = new[] { new OrderItem { ProductVariantId = variant.Id, Quantity = 1, UnitPrice = 10, LineTotal = 10 } }
            };

            context.AddRange(order1, order2);
            await context.SaveChangesAsync();

            var optionsMonitor = new FakeOptionsMonitor<PayPalCleanupOptions>(
                new PayPalCleanupOptions { ExpireAfterMinutes = 10, TickSeconds = 1 });

            var service = new PendingPayPalOrdersCleanupService(scopeFactory, optionsMonitor);

            await InvokeCleanup(service, TimeSpan.FromMinutes(10));

            var updatedOrder1 = await repo.GetByIdAsync<Order>(order1.Id);
            updatedOrder1!.Status.Should().Be(OrderStatus.Cancelled);

            var updatedOrder2 = await repo.GetByIdAsync<Order>(order2.Id);
            updatedOrder2!.Status.Should().Be(OrderStatus.Paid);
        }

        [Fact]
        public async Task OrdersWithoutVariant_ShouldCancelButNotChangeStock()
        {
            var order = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow.AddMinutes(-20),
                Items = new[] { new OrderItem { ProductVariantId = null, Quantity = 1, UnitPrice = 10, LineTotal = 10 } }
            };
            context.Add(order);
            await context.SaveChangesAsync();

            var optionsMonitor = new FakeOptionsMonitor<PayPalCleanupOptions>(
                new PayPalCleanupOptions { ExpireAfterMinutes = 10, TickSeconds = 1 });

            var service = new PendingPayPalOrdersCleanupService(scopeFactory, optionsMonitor);

            await InvokeCleanup(service, TimeSpan.FromMinutes(10));

            var updatedOrder = await repo.GetByIdAsync<Order>(order.Id);
            updatedOrder!.Status.Should().Be(OrderStatus.Cancelled);
        }
    }

    #region Fake helpers
    public class FakeOptionsMonitor<T> : IOptionsMonitor<T> where T : class, new()
    {
        private T _currentValue;
        public FakeOptionsMonitor(T currentValue) { _currentValue = currentValue; }
        public T CurrentValue => _currentValue;
        public T Get(string name) => _currentValue;
        public IDisposable OnChange(Action<T, string> listener) => null!;
    }

    public class FakeServiceScope : IServiceScope
    {
        public FakeServiceScope(IServiceProvider provider) { ServiceProvider = provider; }
        public IServiceProvider ServiceProvider { get; }
        public void Dispose() { }
    }

    public class FakeScopeFactory : IServiceScopeFactory
    {
        private readonly IServiceScope scope;
        public FakeScopeFactory(IServiceScope scope) { this.scope = scope; }
        public IServiceScope CreateScope() => scope;
    }
    #endregion
}
