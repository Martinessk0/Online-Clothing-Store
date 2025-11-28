using Microsoft.AspNetCore.Mvc;
using ClothesShop.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace ClothesShop.Controllers
{
    public class CartController : Controller
    {
        private List<CartItem> GetCartItems()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
                return new List<CartItem>();

            return JsonSerializer.Deserialize<List<CartItem>>(cartJson);
        }

        private void SaveCartItems(List<CartItem> cartItems)
        {
            var cartJson = JsonSerializer.Serialize(cartItems);
            HttpContext.Session.SetString("Cart", cartJson);
        }

        // GET: Cart
        public IActionResult Index()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        // POST: Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int productId, string productName, decimal price, string size, string color, int quantity = 1)
        {
            var cartItems = GetCartItems();

            // Проверяваме дали продуктът вече е в количката
            var existingItem = cartItems.FirstOrDefault(item => item.ProductID == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                // Добавяме нов продукт
                cartItems.Add(new CartItem
                {
                    ProductID = productId,
                    ProductName = productName,
                    Price = price,
                    Size = size,
                    Color = color,
                    Quantity = quantity
                });
            }

            SaveCartItems(cartItems);
            return RedirectToAction("Index");
        }

        // POST: Cart/RemoveFromCart
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cartItems = GetCartItems();
            var itemToRemove = cartItems.FirstOrDefault(item => item.ProductID == productId);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                SaveCartItems(cartItems);
            }

            return RedirectToAction("Index");
        }
    }
}