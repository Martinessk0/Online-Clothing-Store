using ClothingStore.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeedyController : ControllerBase
    {
        private readonly ISpeedyService speedy;

        public SpeedyController(ISpeedyService speedy)
        {
            this.speedy = speedy;
        }

        [HttpGet("offices/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOffice(int id)
        {
            var office = await speedy.GetOfficeByIdAsync(id);
            if (office == null) return NotFound();
            return Ok(office);
        }
    }
}
