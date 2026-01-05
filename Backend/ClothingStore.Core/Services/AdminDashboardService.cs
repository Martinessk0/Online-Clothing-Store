using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Admin;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Core.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IRepository repo;

        public AdminDashboardService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<AdminDashboardStatsDto> GetStatsAsync()
        {
            var totalUsers = await repo
                .AllReadonly<ApplicationUser>()
                .CountAsync();

            var activeStatuses = new[]
            {
                OrderStatus.Pending,
                OrderStatus.Processing,
                OrderStatus.Paid
            };

            var activeOrders = await repo
                .AllReadonly<Order>(o => activeStatuses.Contains(o.Status))
                .CountAsync();

            var activeProducts = await repo
                .AllReadonly<Product>(p => p.IsActive)
                .CountAsync();

            var todayUtc = DateTime.UtcNow.Date;
            var tomorrowUtc = todayUtc.AddDays(1);

            var todayPaidOrdersQuery = repo
                .AllReadonly<Order>(o =>
                    o.CreatedAt >= todayUtc &&
                    o.CreatedAt < tomorrowUtc &&
                    (o.Status == OrderStatus.Paid || o.Status == OrderStatus.Completed));

            var todayOrders = await todayPaidOrdersQuery.CountAsync();

            var todaySalesTotal = await todayPaidOrdersQuery
                .Select(o => (decimal?)o.TotalAmount)
                .SumAsync() ?? 0m;

            return new AdminDashboardStatsDto
            {
                TotalUsers = totalUsers,
                ActiveOrders = activeOrders,
                ActiveProducts = activeProducts,
                TodayOrders = todayOrders,
                TodaySalesTotal = todaySalesTotal
            };
        }
    }
}
