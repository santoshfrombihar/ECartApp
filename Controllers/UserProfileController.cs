using ECartApp.DTO_s;
using ECartApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECartApp.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        public readonly MyCartDbContext _myCartDb;

        public UserProfileController(MyCartDbContext myCartDb)
        {
            _myCartDb = myCartDb;
        }

        public async Task<IActionResult> UserProfile(int userId)
        {
            // Get UserId from claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int authenticatedUserId))
            {
                return RedirectToAction("Login", "Auth");
            }

            // Ensure users can only view their own profile
            if (userId != authenticatedUserId)
            {
                return Forbid();
            }

            var userProfile = await _myCartDb.users
                .Include(up => up.UserProfile)
                .Include(ud => ud.UserAddresses)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (userProfile == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(userProfile);
        }

        public async Task<IActionResult> UpdateProfile(User user)
        {
            var userDetails = await _myCartDb.users
                .Include(x => x.UserProfile)
                .Include(ud => ud.UserAddresses)
                .FirstOrDefaultAsync(x => x.Id == user.Id);

            if (userDetails != null)
            {
                // Update profile fields
                userDetails.UserProfile?.PhoneNumber = user.UserProfile?.PhoneNumber;
                if (user.UserProfile?.Dob != null)
                {
                    userDetails.UserProfile?.Dob = user.UserProfile.Dob;
                }
                userDetails.UserProfile?.Gender = user.UserProfile?.Gender;
                userDetails.FirstName = user.FirstName;
                userDetails.LastName = user?.LastName;
                userDetails.MiddleName = user?.MiddleName;
                userDetails.Email = user?.Email;
                userDetails.UserProfile?.Gender = user?.UserProfile?.Gender;
                await _myCartDb.SaveChangesAsync();
            }

            return RedirectToAction("UserProfile", new { userId = userDetails?.Id });
        }

        public async Task<IActionResult> AddAddress(UserAddressesDto addresses)
        {
            UserAddresses userAddresses = new UserAddresses()
            {
                Address = addresses.Address,
                AddressType = addresses.AddressType,
                City = addresses.City,
                State = addresses.State,
                District = addresses.District,
                PinCode = addresses.PinCode,
                ContactNumber = addresses.PinCode,
                AlternateNumber = addresses.AlternateNumber,
                UserId = addresses.UserId
            };

            await _myCartDb.userAddresses.AddAsync(userAddresses);
            await _myCartDb.SaveChangesAsync();

            return RedirectToAction("UserProfile", new { userId = userAddresses?.UserId });
        }

        public async Task<IActionResult> EditAddress(UserAddresses userAddresses)
        {
            var userAddress = await _myCartDb.userAddresses.FirstOrDefaultAsync(ud => ud.Id == userAddresses.Id);
            if (userAddress != null)
            {
                userAddress.Address = userAddresses.Address;
                userAddress.City = userAddresses.City;
                userAddress.State = userAddresses.State;
                userAddress.District = userAddresses.District;
                userAddress.AddressType = userAddresses.AddressType;
                userAddress.ContactNumber = userAddresses.ContactNumber;
                userAddress.AlternateNumber = userAddresses.AlternateNumber;
                userAddress.PinCode = userAddresses.PinCode;
            }

            await _myCartDb.SaveChangesAsync();
            return RedirectToAction("UserProfile", new { userId = userAddress?.UserId });
        }

        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            var address = await _myCartDb.userAddresses.FirstOrDefaultAsync(ud => ud.Id == addressId);
            var userId = address?.UserId ?? 0;
            if (address != null)
            {
                _myCartDb.Remove(address);
                await _myCartDb.SaveChangesAsync();
            }
            return RedirectToAction("UserProfile", new { userId = userId });
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int userId, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                // 1. Set the folder path
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/profiles");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                // 2. Create unique filename to avoid caching issues and overwriting
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                var filePath = Path.Combine(folder, fileName);

                // 3. Save to the physical path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                // 4. Update the UserProfile in DB
                var user = await _myCartDb.users
                    .Include(u => u.UserProfile)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user != null)
                {
                    if (user.UserProfile == null) user.UserProfile = new UserProfile();

                    user.UserProfile.Photo = "/uploads/profiles/" + fileName;
                    await _myCartDb.SaveChangesAsync();
                }
            }

            return RedirectToAction("UserProfile", new { userId = userId });
        }
    }
}