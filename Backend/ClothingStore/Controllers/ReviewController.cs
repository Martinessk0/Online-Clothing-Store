using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Връща всички ревюта за даден продукт.
        /// GET: api/review/product/1
        /// </summary>
        [HttpGet("product/{productId:int}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetForProduct(int productId)
        {
            var reviews = await _reviewService.GetByProductAsync(productId);
            return Ok(reviews);
        }

        /// <summary>
        /// Създава ново ревю.
        /// POST: api/review
        /// </summary>
        [HttpPost]
        [Authorize] // може да го махнеш, ако Auth още не е готов
        public async Task<ActionResult<int>> Create([FromBody] ReviewCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newId = await _reviewService.CreateAsync(model);

            // Връщаме 201 Created
            return CreatedAtAction(
                nameof(GetForProduct),
                new { productId = model.ProductId },
                new { id = newId });
        }

        /// <summary>
        /// Изтрива ревю по Id (примерно само за Admin).
        /// DELETE: api/review/5
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewService.DeleteAsync(id);
            return NoContent();
        }
    }
}
