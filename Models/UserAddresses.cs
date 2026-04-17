using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECartApp.Models
{
    public class UserAddresses
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? AddressType { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? District { get; set; }

        [StringLength(100)]
        public string? State { get; set; }

        [StringLength(10)]
        public string? PinCode { get; set; }

        [StringLength(20)]
        public string? ContactNumber { get; set; }

        [StringLength(20)]
        public string? AlternateNumber { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
