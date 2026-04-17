namespace ECartApp.DTO_s
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ProductImage { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsProductInCart { get; set; }
    }
}