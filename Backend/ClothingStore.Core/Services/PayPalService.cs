using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Paypal;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ClothingStore.Core.Services
{
    public class PayPalService : IPayPalService
    {
        private readonly HttpClient _http;
        private readonly PayPalOptions _opt;
        private readonly IRepository _repo;

        private string? _cachedToken;
        private DateTime _tokenExpiresAtUtc;

        public PayPalService(HttpClient http, IOptions<PayPalOptions> opt, IRepository repo)
        {
            _http = http;
            _opt = opt.Value;
            _repo = repo;

            // BaseAddress се сетва от AddHttpClient, но ако искаш safety:
            if (_http.BaseAddress is null && !string.IsNullOrWhiteSpace(_opt.BaseUrl))
                _http.BaseAddress = new Uri(_opt.BaseUrl.TrimEnd('/') + "/");
        }

        public async Task<string> CreateCheckoutOrderAsync(int orderId, string? userId)
        {
            var order = await LoadOrderForUser(orderId, userId);
            if (order == null) throw new ArgumentException("Невалидна поръчка.");
            if (order.PaymentMethod != PaymentMethod.PayPal) throw new ArgumentException("Поръчката не е за PayPal.");
            if (order.Status == OrderStatus.Cancelled) throw new ArgumentException("Поръчката е отказана.");

            if (!string.IsNullOrWhiteSpace(order.PayPalOrderId))
                return order.PayPalOrderId!;

            var token = await GetAccessTokenAsync();

            using var req = new HttpRequestMessage(HttpMethod.Post, "v2/checkout/orders");
            req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var payload = new
            {
                intent = "CAPTURE",
                purchase_units = new[]
                {
                    new {
                        reference_id = order.Id.ToString(),
                        amount = new {
                            currency_code = _opt.Currency,
                            value = order.TotalAmount.ToString("0.00", CultureInfo.InvariantCulture)
                        }
                    }
                }
            };

            req.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            using var resp = await _http.SendAsync(req);
            var body = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
                throw new InvalidOperationException($"PayPal Create Order fail: {body}");

            using var doc = JsonDocument.Parse(body);
            var paypalOrderId = doc.RootElement.GetProperty("id").GetString();

            if (string.IsNullOrWhiteSpace(paypalOrderId))
                throw new InvalidOperationException("PayPal не върна order id.");

            order.PayPalOrderId = paypalOrderId;
            await _repo.SaveChangesAsync();

            return paypalOrderId;
        }

        public async Task<bool> CaptureCheckoutOrderAsync(int orderId, string paypalOrderId, string? userId)
        {
            var order = await LoadOrderForUser(orderId, userId);
            if (order == null) return false;
            if (order.PaymentMethod != PaymentMethod.PayPal) return false;

            if (order.Status == OrderStatus.Cancelled) return false;

            if (string.IsNullOrWhiteSpace(order.PayPalOrderId)) return false;
            if (!string.Equals(order.PayPalOrderId, paypalOrderId, StringComparison.Ordinal)) return false;

            // вече платена
            if (order.Status == OrderStatus.Paid && order.PaidAt.HasValue)
                return true;

            var token = await GetAccessTokenAsync();

            using var req = new HttpRequestMessage(HttpMethod.Post, $"v2/checkout/orders/{paypalOrderId}/capture");
            req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            req.Content = new StringContent("{}", Encoding.UTF8, "application/json");

            using var resp = await _http.SendAsync(req);
            var body = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
                throw new InvalidOperationException($"PayPal Capture fail: {body}");

            // при успех: маркираме Paid
            order.Status = OrderStatus.Paid;
            order.PaidAt = DateTime.UtcNow;

            await _repo.SaveChangesAsync();
            return true;
        }

        private async Task<Order?> LoadOrderForUser(int orderId, string? userId)
        {
            var q = _repo.All<Order>()
                .Include(o => o.Items)
                .Where(o => o.Id == orderId);

            if (!string.IsNullOrEmpty(userId))
                q = q.Where(o => o.UserId == userId);

            return await q.FirstOrDefaultAsync();
        }

        private async Task<string> GetAccessTokenAsync()
        {
            if (!string.IsNullOrWhiteSpace(_cachedToken) && DateTime.UtcNow < _tokenExpiresAtUtc)
                return _cachedToken!;

            // OAuth token endpoint
            using var req = new HttpRequestMessage(HttpMethod.Post, "v1/oauth2/token");

            var basic = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_opt.ClientId}:{_opt.ClientSecret}"));
            req.Headers.Authorization = new AuthenticationHeaderValue("Basic", basic);

            req.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type", "client_credentials")
            });

            using var resp = await _http.SendAsync(req);
            var body = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
                throw new InvalidOperationException($"PayPal token fail: {body}");

            using var doc = JsonDocument.Parse(body);
            _cachedToken = doc.RootElement.GetProperty("access_token").GetString();
            var expiresIn = doc.RootElement.GetProperty("expires_in").GetInt32();

            _tokenExpiresAtUtc = DateTime.UtcNow.AddSeconds(Math.Max(30, expiresIn - 60));
            return _cachedToken!;
        }
    }
}
