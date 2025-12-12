using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Store;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orders/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetByUser(string userId)
        {
            var orders = await _orderService.GetByUserAsync(userId);
            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] OrderCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newId = await _orderService.CreateAsync(model);

            return CreatedAtAction(nameof(GetById), new { id = newId }, new { id = newId });
        }

        // PUT: api/orders/{id}/status
        [HttpPut("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] OrderStatusUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _orderService.UpdateStatusAsync(id, model);
            return NoContent();
        }

    }
}
