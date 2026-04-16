using System.ComponentModel.DataAnnotations;

namespace ECartApp.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public virtual Cart? Cart { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        [Range(1, 100)]
        public int Quantity { get; set; }
        public decimal SubTotal => (Product?.Price ?? 0) * Quantity;
    }
}