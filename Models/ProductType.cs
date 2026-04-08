using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECartApp.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string? Category { get; set; }
        public List<Product>? Products { get; set; }
    }
}
