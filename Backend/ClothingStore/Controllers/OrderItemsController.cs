using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Entities;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // => api/OrderItems
    public class OrderItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderItems/order/5
        [HttpGet("order/{orderId:int}")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetItemsForOrder(int orderId)
        {
            var items = await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();

            return Ok(items);
        }


        // GET: api/OrderItems/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/OrderItems
        [HttpPost]
        public async Task<ActionResult<OrderItem>> CreateOrderItem([FromBody] OrderItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderItems.Add(item);
            await _context.SaveChangesAsync();

            // Ако ключът ти е Id в OrderItem (както е в entity-то):
            return CreatedAtAction(nameof(GetOrderItem),
                new { id = item.Id },  // ТУК беше item.OrderItemID
                item);

        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
