using ECartApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace ECartApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly MyCartDbContext _context;

        public OrderController(MyCartDbContext context)
        {
            _context = context;
        }

        public IActionResult OrderDetails()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart(int productId)
        {
            // Get UserId from claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            var cart = await _context.carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                await _context.carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = await _context.cartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cart.Id && ci.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = 1
                };
                await _context.cartItems.AddAsync(cartItem);
            }

            var distinctProductsCount = await _context.cartItems
                .Where(ci => ci.Cart.UserId == userId)
                .CountAsync();

            TempData["cartCount"] = distinctProductsCount;
            await _context.SaveChangesAsync();
            return RedirectToAction("Deskboard", "Deskboard");
        }
    }
}
