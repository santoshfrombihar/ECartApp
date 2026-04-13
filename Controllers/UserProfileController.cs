using ECartApp.DTO_s;
using ECartApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECartApp.Controllers
{
    public class UserProfileController : Controller
    {
        public readonly MyCartDbContext _myCartDb;

        public UserProfileController(MyCartDbContext myCartDb)
        {
            _myCartDb = myCartDb;
        }

        public async Task<IActionResult> UserProfile(int userId)
        {
            var userProfile = await _myCartDb.users.Include(up => up.UserProfile).Include(ud => ud.UserAddresses).FirstOrDefaultAsync(u => u.Id == userId);
            return View(userProfile);
        }

        public async Task<IActionResult> UpdateProfile(User user)
        {
             var userDetails = await _myCartDb.users
                .Include(x => x.UserProfile).Include(ud => ud.UserAddresses)
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
            if(userAddress != null)
            {
               userAddress.Address = userAddresses.Address;
               userAddress.City = userAddresses.City;
               userAddress.State = userAddresses.State;
               userAddress.District  = userAddresses.District;
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
            var userId = address.UserId;
            if (address != null)
            {
                 _myCartDb.Remove(address);
                await _myCartDb.SaveChangesAsync();
            }
            return RedirectToAction("UserProfile", new { userId = userId });
        }
    }
}
   