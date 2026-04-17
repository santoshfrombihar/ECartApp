using System.Diagnostics;
using System.Security.Claims;
using ECartApp.DTO_s;
using ECartApp.Models;
using ECartApp.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ECartApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly MyCartDbContext _myCartDb;
        private readonly IConfiguration _config;

        public AuthController(MyCartDbContext myCartDb, IConfiguration config)
        {
            _myCartDb = myCartDb;
            _config = config;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
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

            // Generate JWT Token
            if (user?.Email != null)
            {
                var tokenGenerator = new JwtTokenGenrator(_config);
                string token = tokenGenerator.GenerateToken(user.Id, user.Email, user.Role ?? "Customer");

                // Create claims for Cookie Authentication
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Role, user.Role ?? "Customer"),
                    new Claim("JWToken", token)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15)
                };

                // Sign in with Cookie
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Store in session as backup
                HttpContext.Session.SetString("JWToken", token);
                HttpContext.Session.SetInt32("UserId", user.Id);
            }

            return RedirectToAction("Deskboard", "Deskboard");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto registerDto)
        {
            if (string.IsNullOrEmpty(registerDto.FirstName) || string.IsNullOrEmpty(registerDto.LastName) ||
                string.IsNullOrEmpty(registerDto.Email) || string.IsNullOrEmpty(registerDto.Password))
            {
                ViewBag.Message = "Fill the required details";
                return View();
            }

            var existingUser = await _myCartDb.users.FirstOrDefaultAsync(r => r.Email == registerDto.Email);

            if (existingUser != null)
            {
                ViewBag.Message = "User Already Registered";
                return View();
            }

            var user = new User()
            {
                FirstName = registerDto.FirstName,
                MiddleName = registerDto.MiddleName,
                LastName = registerDto.LastName,
                Password = registerDto.Password,
                Email = registerDto.Email,
                Role = "Customer"
            };

            await _myCartDb.users.AddAsync(user);
            await _myCartDb.SaveChangesAsync();

            var userProfile = new UserProfile()
            {
                UserId = user.Id,
            };
            await _myCartDb.userprofiles.AddAsync(userProfile);
            await _myCartDb.SaveChangesAsync();

            TempData["Message"] = "Registration Successful. Please login.";
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
