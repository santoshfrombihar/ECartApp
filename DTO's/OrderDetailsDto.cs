using System.ComponentModel.DataAnnotations;
using ECartApp.Models;

namespace ECartApp.DTO_s
{
    public class OrderDetailsDto
    {
       public int UserId { get; set; }
       public List<ProductDto>? Products { get; set; }
       public List<CartItem>? CartItems { get; set; }
       public List<UserAddressesDto>? UserAddresses { get; set; }
    }
}
