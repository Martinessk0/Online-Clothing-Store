using ClothingStore.Core.Models.Paypal;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ClothingStore.Core.Services
{
    public class PendingPayPalOrdersCleanupService : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly IOptionsMonitor<PayPalCleanupOptions> opt;

        public PendingPayPalOrdersCleanupService(
            IServiceScopeFactory scopeFactory,
            IOptionsMonitor<PayPalCleanupOptions> opt)
        {
            this.scopeFactory = scopeFactory;
            this.opt = opt;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var expireAfter = TimeSpan.FromMinutes(opt.CurrentValue.ExpireAfterMinutes);
                var tick = TimeSpan.FromSeconds(opt.CurrentValue.TickSeconds);

                try
                {
                    await CleanupOnce(expireAfter,stoppingToken);
                }
                catch
                {
                }

                await Task.Delay(tick, stoppingToken);
            }
        }

        private async Task CleanupOnce(TimeSpan expireAfter,CancellationToken ct)
        {
            using var scope = scopeFactory.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<IRepository>();

            var cutoff = DateTime.UtcNow.Subtract(expireAfter);

            var expired = await repo.All<Order>()
                .Include(o => o.Items)
                .Where(o =>
                    o.PaymentMethod == PaymentMethod.PayPal &&
                    o.Status == OrderStatus.Pending &&
                    o.CreatedAt < cutoff)
                .ToListAsync(ct);

            if (!expired.Any())
                return;

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
