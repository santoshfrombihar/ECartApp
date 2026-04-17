using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECartApp.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public User? User { get; set; }
        public ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();
    }
}
