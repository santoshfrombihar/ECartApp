using System.ComponentModel.DataAnnotations;

namespace ECartApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductImage { get; set; }
        public decimal? Price { get; set; }
        public ProductType? Type { get; set; }
        public ProductColor? Color { get; set; }

    }
}
