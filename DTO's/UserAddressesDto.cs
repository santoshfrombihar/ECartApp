using ECartApp.Models;

namespace ECartApp.DTO_s
{
    public class UserAddressesDto
    {
        public int Id { get; set; }
        public string? AddressType { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? PinCode { get; set; }
        public string? ContactNumber { get; set; }
        public string? AlternateNumber { get; set; }
        public int UserId { get; set; }
    }
}
