using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/admin/orders")]
    [Authorize(Roles = "Admin")]
    public class AdminOrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILogger<AdminOrdersController> logger;

        public AdminOrdersController(IOrderService orderService, ILogger<AdminOrdersController> logger)
        {
            this.orderService = orderService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminOrderListItemDto>>> GetAll()
        {
            var orders = await orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("statuses")]
        public async Task<ActionResult<IEnumerable<string>>> GetStatuses()
        {
            var statuses = await orderService.GetAllStatusesAsync();
            return Ok(statuses);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateOrderStatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await orderService.UpdateOrderStatusAsync(id, dto.Status);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminOrderDetailsDto>> GetById(int id)
        {
            var dto = await orderService.GetAdminOrderDetailsAsync(id);
            if (dto == null) return NotFound();

            return Ok(dto);
        }

    }
}
