using ECartApp.DTO_s;
using ECartApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECartApp.Controllers
{
    [Authorize]
    public class DeskboardController : Controller
    {
        private readonly MyCartDbContext _context;

        public DeskboardController(MyCartDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Deskboard()
        {
            // Get UserId from claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if(int.TryParse(userIdClaim.Value, out int userId))
            {
                ViewBag.UserId = userId;
            }
            
            var userCartProductIds = await _context.carts
                .Where(c => c.UserId == userId)
                .SelectMany(c => c.CartItems.Select(ci => ci.ProductId))
                .ToListAsync();

            var products = await _context.products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    Price = p.Price,
                    ProductImage = p.ProductImage,
                    IsProductInCart = userCartProductIds.Contains(p.Id)
                })
                .ToListAsync();


            var distinctProductsCount = await _context.cartItems
                .Where(ci => ci.Cart.UserId == userId)
                .CountAsync();

            ViewBag.CartCount = distinctProductsCount;

            return View(products);
        }
    }
}
