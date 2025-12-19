using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClothingStore.Core.Services
{
    public class PendingPayPalOrdersCleanupService : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;

        // След колко време да се “освободи” стоката (можеш да го направиш setting)
        private static readonly TimeSpan ExpireAfter = TimeSpan.FromMinutes(1);

        // Колко често да проверява
        private static readonly TimeSpan Tick = TimeSpan.FromMinutes(10);

        public PendingPayPalOrdersCleanupService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await CleanupOnce(stoppingToken);
                }
                catch
                {
                    // не спираме worker-а при грешка
                }

                await Task.Delay(Tick, stoppingToken);
            }
        }

        private async Task CleanupOnce(CancellationToken ct)
        {
            using var scope = scopeFactory.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<IRepository>();

            var cutoff = DateTime.UtcNow.Subtract(ExpireAfter);

            var expired = await repo.All<Order>()
                .Include(o => o.Items)
                .Where(o =>
                    o.PaymentMethod == PaymentMethod.PayPal &&
                    o.Status == OrderStatus.Pending &&
                    o.CreatedAt < cutoff)
                .ToListAsync(ct);

            if (!expired.Any())
                return;

            // Връщаме stock само за variant-и (както ти е логиката)
            var variantIds = expired
                .SelectMany(o => o.Items)
                .Where(i => i.ProductVariantId.HasValue)
                .Select(i => i.ProductVariantId!.Value)
                .Distinct()
                .ToList();

            var variants = await repo.All<ProductVariant>()
                .Where(v => variantIds.Contains(v.Id))
                .ToListAsync(ct);

            foreach (var order in expired)
            {
                foreach (var item in order.Items)
                {
                    if (!item.ProductVariantId.HasValue) continue;

                    var v = variants.FirstOrDefault(x => x.Id == item.ProductVariantId.Value);
                    if (v == null) continue;

                    v.Stock += item.Quantity;
                    repo.Update(v);
                }

                order.Status = OrderStatus.Cancelled;
            }

            await repo.SaveChangesAsync();
        }
    }
}
