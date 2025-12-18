using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Recommendation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackingController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;
        private readonly ILogger<TrackingController> _logger;

        public TrackingController(
            IRecommendationService recommendationService,
            ILogger<TrackingController> logger)
        {
            _recommendationService = recommendationService;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Track([FromBody] TrackInteractionDto dto)
        {
            try
            {
                string? userId = null;
                if (User?.Identity?.IsAuthenticated == true)
                {
                    userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                }

                await _recommendationService.TrackInteractionAsync(userId, dto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while tracking interaction.");
                return StatusCode(500, new { message = "Error while tracking interaction." });
            }
        }
    }
}
