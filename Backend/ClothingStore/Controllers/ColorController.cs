using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Color;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : Controller
    {
        private readonly IColorService colorService;

        public ColorController(IColorService colorService)
        {
            this.colorService = colorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ColorDTO>>> All()
        {
            var result = await colorService.GetAllAsync();
            return Ok(result);
        }
    }
}