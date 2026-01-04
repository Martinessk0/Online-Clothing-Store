using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/admin/dashboard")]
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : ControllerBase
    {
        private readonly IAdminDashboardService dashboardService;
        private readonly ILogger<AdminDashboardController> logger;

        public AdminDashboardController(
            IAdminDashboardService dashboardService,
            ILogger<AdminDashboardController> logger)
        {
            this.dashboardService = dashboardService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<AdminDashboardStatsDto>> Get()
        {
            try
            {
                var stats = await dashboardService.GetStatsAsync();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to load admin dashboard stats.");
                return StatusCode(500, new { message = "Възникна грешка при зареждане на статистиката." });
            }
        }
    }
}
