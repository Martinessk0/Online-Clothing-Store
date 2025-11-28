using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClothesShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        // ====== помощни методи за кошницата (Session) ======
        private List<CartItem> GetCartItems()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
                return new List<CartItem>();

            return JsonSerializer.Deserialize<List<CartItem>>(cartJson);
        }

        private void ClearCart()
        {
            HttpContext.Session.Remove("Cart");
        }

        // ====== LIST ORDERS ======
        // GET: /Order
        public async Task<IActionResult> Index()
        {
            // Взимаме някакъв потребител (както при Review)
            var user = await _context.Users.FirstOrDefaultAsync();
            if (user == null)
            {
                user = new User
                {
                    Username = "TestUser",
                    Email = "test@example.com",
                    PasswordHash = "123",
                    CreatedAt = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            var orders = await _context.Orders
                .Where(o => o.UserID == user.UserID)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }

        // ====== ORDER DETAILS ======
        // GET: /Order/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
                return NotFound();

            ViewBag.OrderId = order.OrderID;
            return View(order.OrderItems);
        }

        // ====== CHECKOUT: Cart -> Order ======
        // POST: /Order/CreateOrder
        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            var cartItems = GetCartItems();

            // ако кошницата е празна -> връщаме към Cart
            if (cartItems == null || !cartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            // взимаме или създаваме user
            var user = await _context.Users.FirstOrDefaultAsync();
            if (user == null)
            {
                user = new User
                {
                    Username = "TestUser",
                    Email = "test@example.com",
                    PasswordHash = "123",
                    CreatedAt = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            // създаваме поръчка
            var order = new Order
            {
                UserID = user.UserID,
                OrderDate = DateTime.Now,
                Status = "Processing",
                TotalPrice = cartItems.Sum(ci => ci.Price * ci.Quantity)
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // добавяме OrderItems от кошницата
            foreach (var ci in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderID = order.OrderID,
                    ProductID = ci.ProductID,
                    Quantity = ci.Quantity,
                    Price = ci.Price
                };

                _context.OrderItems.Add(orderItem);
            }

            await _context.SaveChangesAsync();

            // чистим количката
            ClearCart();

            // към детайлите на новата поръчка
            return RedirectToAction("Details", new { id = order.OrderID });
        }
    }
}
