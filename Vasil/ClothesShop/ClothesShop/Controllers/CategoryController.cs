using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothesShop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // AddCategory() -> Index + Create

        // GET: Category
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create  
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // UpdateCategory() -> Edit

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategoryID)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // DeleteCategory() -> Delete

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.CategoryID == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Products by Category

        public async Task<IActionResult> Products(int id)
        {
            var products = await _context.Products
                .Where(p => p.CategoryID == id)
                .ToListAsync();

            ViewBag.CategoryId = id;
            return View(products);
        }

        // GET: Category/AddProduct/5
        public IActionResult AddProduct(int categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }

        // POST: Category/AddProduct
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Products", new { id = product.CategoryID });
            }

            ViewBag.CategoryId = product.CategoryID;
            return View(product);
        }
    }
}
