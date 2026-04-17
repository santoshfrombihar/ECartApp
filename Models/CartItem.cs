using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECartApp.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Cart")]
        public int CartId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual Product? Product { get; set; }

        [NotMapped]
        public decimal SubTotal => (Product?.Price ?? 0) * Quantity;
    }
}