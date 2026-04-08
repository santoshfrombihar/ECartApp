using System.Diagnostics;
using ECartApp.DTO_s;
using ECartApp.Models;
using ECartApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ECartApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly MyCartDbContext _myCartDb;
        private readonly IConfiguration _config;
        public AuthController(MyCartDbContext myCartDb, IConfiguration confing)
        {
            _myCartDb = myCartDb;
            _config = confing;
        }
      
        public async Task<IActionResult> Login(LoginDto login)
        {
            // 1. Basic Validation
            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                ViewBag.Message = "Email and Password are required.";
                return View();
            }

            // 2. Fetch the user from the database
            // We use 'await' here so the thread can do other work while the DB searches
            var user = await _myCartDb.register.FirstOrDefaultAsync(e => e.Email == login.Email);

            // 3. Logic Check: Does the user exist?
            if (user == null)
            {
                ViewBag.Message = "User not registered. Please register first.";
                return View();
            }

            // 4. Logic Check: Does the password match?
            // Note: In a real app, you would use a password hasher here
            if (user.Password != login.Password)
            {
                ViewBag.Message = "Invalid email or password.";
                return View();
            }

            // 5. Success! Generate the JWT Token
            var generator = new JwtTokenGenrator(_config);
            string token = generator.GenerateToken(user.Email);

            // 6. Handle the Token
            // In MVC, you might pass it to a View or save it in a Cookie
            ViewBag.Token = token;
            ViewBag.Message = "Login Successful!";

            return View();
        }

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!string.IsNullOrEmpty(registerDto.FirstName) && !string.IsNullOrEmpty(registerDto.LastName) &&  !string.IsNullOrEmpty(registerDto.Email) && !string.IsNullOrEmpty(registerDto.Password))
            {
                var user = _myCartDb.register.FirstOrDefault(r=>r.Email == registerDto.Email);
                if (user == null)
                {
                    Register reg = new Register()
                    { 
                        FirstName = registerDto.FirstName,
                        MiddleName = registerDto.MiddleName,
                        LastName = registerDto.LastName,
                        Password = registerDto.Password,
                        Email = registerDto.Email,
                    };

                    await _myCartDb.AddAsync(reg);
                    await _myCartDb.SaveChangesAsync();
                    TempData["Message"] = "Registration Sucessfull";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Message = "User Already Register";
                    return View();
                }
            }
            ViewBag.Message = "Fill the required details";
            return View();
        }
    }
}
