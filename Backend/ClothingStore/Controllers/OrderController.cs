using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrderController> logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            this.orderService = orderService;
            this.logger = logger;
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] OrderCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userId = GetUserId();

                if (string.IsNullOrEmpty(userId))
                {
                    if (string.IsNullOrWhiteSpace(dto.CustomerName) ||
                        string.IsNullOrWhiteSpace(dto.Email) ||
                        string.IsNullOrWhiteSpace(dto.Phone) ||
                        string.IsNullOrWhiteSpace(dto.Address))
                    {
                        return BadRequest(new
                        {
                            message = "Име, имейл, телефон и адрес са задължителни за поръчка без регистрация."
                        });
                    }
                }

                var orderId = await orderService.CreateOrderAsync(dto, userId);
                return Ok(new { orderId });
            }
            catch (ArgumentException ex)
            {
                logger.LogWarning(ex, "Invalid order data.");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating order.");
                return StatusCode(500, new { message = "Възникна грешка при създаване на поръчката." });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var userId = GetUserId();

            var order = await orderService.GetOrderAsync(id, userId);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("my")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetMyOrders()
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var orders = await orderService.GetUserOrdersAsync(userId);
            return Ok(orders);
        }
    }
}
