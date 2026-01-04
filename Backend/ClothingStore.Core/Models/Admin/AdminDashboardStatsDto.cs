namespace ClothingStore.Core.Models.Admin
{
    public class AdminDashboardStatsDto
    {
        public int TotalUsers { get; set; }

        public int ActiveOrders { get; set; }

        public int ActiveProducts { get; set; }

        public int TodayOrders { get; set; }

        public decimal TodaySalesTotal { get; set; }
    }
}
