namespace ECartApp.DTO_s
{
    public class UserProfileDto
    {
        public int UserId { get; set; }
        public string? Photo { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly Dob { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? PinCode { get; set; }
    }
}
