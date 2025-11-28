using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothesShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShop.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Review/Create/5 (5 = productId)
        public IActionResult Create(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public async Task<IActionResult> Create(int productId, int rating, string comment)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(comment))
            {
                // ако няма user — създаваме един
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

                var review = new Review
                {
                    ProductID = productId,
                    UserID = user.UserID,
                    Rating = rating,
                    Comment = comment,
                    Status = "Approved",
                    CreatedAt = DateTime.Now
                };

                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                return RedirectToAction("ProductReviews", new { id = productId });
            }

            ViewBag.ProductId = productId;
            return View();
        }

        // GET: Review/ProductReviews/5
        public async Task<IActionResult> ProductReviews(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductID == id);

            if (product == null)
                return NotFound();

            var reviews = await _context.Reviews
                .Where(r => r.ProductID == id && r.Status == "Approved")
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            ViewBag.ProductId = id;
            ViewBag.CategoryId = product.CategoryID;

            return View(reviews);
        }
    }
}
