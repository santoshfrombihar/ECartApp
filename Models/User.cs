using System.ComponentModel.DataAnnotations;

namespace ECartApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 100 characters")]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 100 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(255)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string? Password { get; set; }

        [StringLength(50)]
        public string Role { get; set; } = "Customer";

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        // Navigation properties
        public UserProfile? UserProfile { get; set; }
        public List<UserAddresses>? UserAddresses { get; set; } = new List<UserAddresses>();
        public List<Cart>? Carts { get; set; } = new List<Cart>();
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
