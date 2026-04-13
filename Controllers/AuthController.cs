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
            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                ViewBag.Message = "Email and Password are required.";
                return View();
            }

            var user = await _myCartDb.users.FirstOrDefaultAsync(e => e.Email == login.Email);

            if (user == null)
            {
                ViewBag.Message = "User not registered. Please register first.";
                return View();
            }
            if (user.Password != login.Password)
            {
                ViewBag.Message = "Invalid email or password.";
                return View();
            }

            var generator = new JwtTokenGenrator(_config);
            string token = generator.GenerateToken(user.Email);
            CookieOptions option = new CookieOptions();
            option.HttpOnly = true;
            option.Expires = DateTime.Now.AddMinutes(60);
            Response.Cookies.Append("JWToken", token, option);

            HttpContext.Session.SetString("JWToken", token);
            ViewBag.Token = token;
            ViewBag.Message = "Login Successful!";
            TempData["UserId"] = user.Id;
            return RedirectToAction("Deskboard", "Deskboard");
        }

        public async Task<IActionResult> Register(UserDto registerDto)
        {
            if (!string.IsNullOrEmpty(registerDto.FirstName) && !string.IsNullOrEmpty(registerDto.LastName) &&  !string.IsNullOrEmpty(registerDto.Email) && !string.IsNullOrEmpty(registerDto.Password))
            {
                var user = _myCartDb.users.FirstOrDefault(r=>r.Email == registerDto.Email);
                if (user == null)
                {
                    User reg = new User()
                    { 
                        FirstName = registerDto.FirstName,
                        MiddleName = registerDto.MiddleName,
                        LastName = registerDto.LastName,
                        Password = registerDto.Password,
                        Email = registerDto.Email,
                    };

                    await _myCartDb.AddAsync(reg);
                    await _myCartDb.SaveChangesAsync();
                    UserProfile userProfile = new UserProfile()
                    {
                        UserId = reg.Id,
                    };
                    await _myCartDb.AddAsync(userProfile);
                    await _myCartDb.SaveChangesAsync();
                    TempData["Message"] = "Registration Successful";
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
