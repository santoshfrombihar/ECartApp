using System.ComponentModel.DataAnnotations;

namespace ECartApp.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public string? Photo { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly Dob { get; set; }
        public string? Gender { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

    }
}