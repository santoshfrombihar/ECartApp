using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECartApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 200 characters")]
        public string? ProductName { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? ProductDescription { get; set; }

        [StringLength(500)]
        public string? ProductImage { get; set; }

        [Range(0.01, 999999.99, ErrorMessage = "Price must be between 0.01 and 999999.99")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int? TypeId { get; set; }
        public ProductType? Type { get; set; }

        public int? ColorId { get; set; }
        public ProductColor? Color { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
    }
}
