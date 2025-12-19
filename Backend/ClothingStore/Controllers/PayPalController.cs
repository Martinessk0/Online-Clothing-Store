using ClothingStore.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayPalController : ControllerBase
    {
        private readonly IPayPalService paypal;

        public PayPalController(IPayPalService paypal)
        {
            this.paypal = paypal;
        }

        private string? GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public record CreateReq(int OrderId);
        public record CaptureReq(int OrderId, string PayPalOrderId);

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateReq req)
        {
            var id = await paypal.CreateCheckoutOrderAsync(req.OrderId, GetUserId());
            return Ok(new { paypalOrderId = id });
        }

        [HttpPost("capture")]
        [AllowAnonymous]
        public async Task<IActionResult> Capture([FromBody] CaptureReq req)
        {
            var ok = await paypal.CaptureCheckoutOrderAsync(req.OrderId, req.PayPalOrderId, GetUserId());
            if (!ok) return BadRequest(new { message = "Неуспешно PayPal плащане." });
            return Ok(new { success = true });
        }
    }
}
