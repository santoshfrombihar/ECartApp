using ECartApp.Models;

namespace ECartApp.DTO_s
{
    public class OrderDetailsDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Cart items
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

        // Buy-now product (optional)
        public OrderItemDto? BuyNowProduct { get; set; }

        // User addresses
        public List<UserAddressesDto> UserAddresses { get; set; } = new List<UserAddressesDto>();

        // Financial calculations
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public string PaymentMethod { get; set; } = "UPI";
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Calculated property
        public decimal TotalPrice => UnitPrice * Quantity;
    }

    public class UserAddressesDto
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string AddressType { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string? AlternateNumber { get; set; }
        public int UserId { get; set; }
    }
}