using ClothingStore.Core.Services;
using ClothingStore.Core.Models.Paypal;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using ClothingStore.UnitTests.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ClothingStore.UnitTests.Payments
{
    public class PayPalServiceTests
    {
        private readonly AppDbContext context;
        private readonly IRepository repo;
        private readonly PayPalService service;

        public PayPalServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new AppDbContext(options);
            repo = new Repository(context);

            var httpClient = new HttpClient(new FakeHttpMessageHandler(HandleHttp))
            {
                BaseAddress = new Uri("https://fake-paypal/")
            };

            var paypalOptions = Options.Create(new PayPalOptions
            {
                ClientId = "test",
                ClientSecret = "secret",
                Currency = "BGN"
            });

            service = new PayPalService(httpClient, paypalOptions, repo);
        }

        private HttpResponseMessage HandleHttp(HttpRequestMessage req)
        {
            if (req.RequestUri!.AbsolutePath.Contains("oauth2"))
            {
                return Json(new
                {
                    access_token = "fake-token",
                    expires_in = 3600
                });
            }

            if (req.RequestUri!.AbsolutePath.Contains("checkout/orders")
                && req.Method == HttpMethod.Post
                && !req.RequestUri.AbsolutePath.Contains("capture"))
            {
                return Json(new { id = "PAYPAL-ORDER-123" });
            }

            if (req.RequestUri!.AbsolutePath.Contains("capture"))
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                };
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        private HttpResponseMessage Json(object obj)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(obj),
                    Encoding.UTF8,
                    "application/json")
            };
        }

        [Fact]
        public async Task CreateCheckoutOrderAsync_ValidOrder_ShouldCreatePayPalOrder()
        {
            var order = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                TotalAmount = 100,
                Status = OrderStatus.Pending
            };

            context.Add(order);
            await context.SaveChangesAsync();

            var result = await service.CreateCheckoutOrderAsync(order.Id, null);

            result.Should().Be("PAYPAL-ORDER-123");

            var updated = await repo.GetByIdAsync<Order>(order.Id);
            updated!.PayPalOrderId.Should().Be("PAYPAL-ORDER-123");
        }

        [Fact]
        public async Task CaptureCheckoutOrderAsync_Valid_ShouldMarkOrderAsPaid()
        {
            var order = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                TotalAmount = 50,
                Status = OrderStatus.Pending,
                PayPalOrderId = "PAYPAL-ORDER-123"
            };

            context.Add(order);
            await context.SaveChangesAsync();

            var result = await service.CaptureCheckoutOrderAsync(
                order.Id,
                "PAYPAL-ORDER-123",
                null);

            result.Should().BeTrue();

            var updated = await repo.GetByIdAsync<Order>(order.Id);
            updated!.Status.Should().Be(OrderStatus.Paid);
            updated.PaidAt.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateCheckoutOrderAsync_NotPayPal_ShouldThrow()
        {
            var order = new Order
            {
                PaymentMethod = PaymentMethod.CashOnDelivery,
                TotalAmount = 20,
                Status = OrderStatus.Pending
            };

            context.Add(order);
            await context.SaveChangesAsync();

            Func<Task> act = async () =>
                await service.CreateCheckoutOrderAsync(order.Id, null);

            await act.Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Поръчката не е за PayPal.");
        }

        [Fact]
        public async Task CreateCheckoutOrderAsync_CancelledOrder_ShouldThrow()
        {
            var order = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                TotalAmount = 30,
                Status = OrderStatus.Cancelled
            };

            context.Add(order);
            await context.SaveChangesAsync();

            Func<Task> act = async () =>
                await service.CreateCheckoutOrderAsync(order.Id, null);

            await act.Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Поръчката е отказана.");
        }

        [Fact]
        public async Task CreateCheckoutOrderAsync_AlreadyHasPayPalOrderId_ShouldReturnIt()
        {
            var order = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                TotalAmount = 40,
                Status = OrderStatus.Pending,
                PayPalOrderId = "EXISTING-ID"
            };

            context.Add(order);
            await context.SaveChangesAsync();

            var result = await service.CreateCheckoutOrderAsync(order.Id, null);

            result.Should().Be("EXISTING-ID");
        }

        [Fact]
        public async Task CaptureCheckoutOrderAsync_WrongPayPalOrderId_ShouldReturnFalse()
        {
            var order = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                Status = OrderStatus.Pending,
                PayPalOrderId = "CORRECT-ID"
            };

            context.Add(order);
            await context.SaveChangesAsync();

            var result = await service.CaptureCheckoutOrderAsync(
                order.Id,
                "WRONG-ID",
                null);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task CaptureCheckoutOrderAsync_AlreadyPaid_ShouldReturnTrue()
        {
            var order = new Order
            {
                PaymentMethod = PaymentMethod.PayPal,
                Status = OrderStatus.Paid,
                PaidAt = DateTime.UtcNow,
                PayPalOrderId = "PAYPAL-ORDER-123"
            };

            context.Add(order);
            await context.SaveChangesAsync();

            var result = await service.CaptureCheckoutOrderAsync(
                order.Id,
                "PAYPAL-ORDER-123",
                null);

            result.Should().BeTrue();
        }

    }
}
