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
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.UserId = userId;

            var products = await _context.products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    Price = p.Price,
                    ProductImage = p.ProductImage
                })
                .ToListAsync();

            return View(products);
        }
    }
}
