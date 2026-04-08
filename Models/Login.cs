using System.ComponentModel.DataAnnotations;

namespace ECartApp.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
