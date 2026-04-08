using ECartApp.DTO_s;
using ECartApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECartApp.Controllers
{
    public class DeskboardController : Controller
    {
        private readonly MyCartDbContext _myCartDb;
        public DeskboardController(MyCartDbContext myCartDb)
        {
            _myCartDb = myCartDb;
        }
        public async Task<IActionResult> Deskboard()
        {
            var products = await _myCartDb.products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductImage = p.ProductImage,
                Price = p.Price,
                //Type = p.Type,
                //Color = p.Color
            })
            .ToListAsync();
            return View(products);
        }
    }
}
