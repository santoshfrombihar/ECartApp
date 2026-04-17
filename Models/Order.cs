using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECartApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GSTAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalAmount { get; set; }

        [StringLength(50)]
        public string? CouponCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CouponDiscount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = "UPI";

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public DateTime? DeliveryDate { get; set; }

        [StringLength(500)]
        public string? DeliveryAddress { get; set; }

        [StringLength(20)]
        public string? ContactNumber { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public User? User { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
    }
}