using System.ComponentModel.DataAnnotations;

namespace ECartApp.Models
{
    public class ProductColor
    {
        [Key]
        public int Id { get; set; }
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
        public List<Product>? Products { get; set; }
    }
}
