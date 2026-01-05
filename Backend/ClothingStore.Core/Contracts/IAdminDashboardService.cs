using ClothingStore.Core.Models.Admin;

namespace ClothingStore.Core.Contracts
{
    public interface IAdminDashboardService
    {
        Task<AdminDashboardStatsDto> GetStatsAsync();
    }
}