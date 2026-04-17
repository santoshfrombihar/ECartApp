using ECartApp.DTO_s;
using ECartApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECartApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly MyCartDbContext _context;

        public OrderController(MyCartDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails(int? productId = null)
        {
            // Get UserId from claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            // Get user info
            var user = await _context.users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Get user's cart
            var cart = await _context.carts.FirstOrDefaultAsync(c => c.UserId == userId);
            
            // Get user's cart items with product details
            var cartItems = new List<CartItem>();
            if (cart != null)
            {
                cartItems = await _context.cartItems
                    .Include(ci => ci.Product)
                    .Where(ci => ci.CartId == cart.Id)
                    .ToListAsync();
            }

            // Get user addresses
            var userAddresses = await _context.userAddresses
                .Where(ua => ua.UserId == userId)
                .ToListAsync();

            // Map cart items to DTOs
            var cartItemDtos = cartItems.Select(ci => new OrderItemDto
            {
                ProductId = ci.Product?.Id ?? 0,
                ProductName = ci.Product?.ProductName,
                ProductImage = ci.Product?.ProductImage,
                Quantity = ci.Quantity,
                UnitPrice = ci.Product?.Price ?? 0
            }).ToList();

            // Handle Buy Now product if productId provided
            OrderItemDto buyNowProductDto = null;
            if (productId.HasValue && productId > 0)
            {
                var buyNowProduct = await _context.products.FirstOrDefaultAsync(p => p.Id == productId.Value);
                if (buyNowProduct != null)
                {
                    buyNowProductDto = new OrderItemDto
                    {
                        ProductId = buyNowProduct.Id,
                        ProductName = buyNowProduct.ProductName,
                        ProductImage = buyNowProduct.ProductImage,
                        Quantity = 1,
                        UnitPrice = buyNowProduct.Price
                    };
                }
            }

            // Calculate totals (include both cart items and buy-now product)
            decimal subtotal = cartItemDtos.Sum(ci => ci.UnitPrice * ci.Quantity);
            if (buyNowProductDto != null)
            {
                subtotal += buyNowProductDto.UnitPrice * buyNowProductDto.Quantity;
            }

            decimal discountAmount = subtotal * 0.2m; // 20% discount
            decimal gstAmount = (subtotal - discountAmount) * 0.18m; // 18% GST
            decimal finalAmount = subtotal - discountAmount + gstAmount;

            // Map to DTO
            var orderDto = new OrderDetailsDto
            {
                UserId = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                OrderItems = cartItemDtos,
                BuyNowProduct = buyNowProductDto,
                UserAddresses = userAddresses.Select(ua => new UserAddressesDto
                {
                    Id = ua.Id,
                    Address = ua.Address,
                    City = ua.City,
                    State = ua.State,
                    District = ua.District,
                    PinCode = ua.PinCode,
                    AddressType = ua.AddressType,
                    ContactNumber = ua.ContactNumber
                }).ToList(),
                TotalAmount = subtotal,
                DiscountAmount = discountAmount,
                GSTAmount = gstAmount,
                FinalAmount = finalAmount,
                PaymentMethod = "UPI"
            };

            ViewBag.CartCount = cartItems.Count;

            return View(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrderDetailsDto orderDto, string paymentMethod, string couponCode = "")
        {
            // Get UserId from claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            try
            {
                // Create new Order
                var order = new Order
                {
                    UserId = userId,
                    OrderNumber = "ORD-" + DateTime.Now.Ticks,
                    TotalAmount = orderDto.TotalAmount,
                    DiscountAmount = orderDto.DiscountAmount,
                    GSTAmount = orderDto.GSTAmount,
                    FinalAmount = orderDto.FinalAmount,
                    CouponCode = couponCode,
                    Status = "Pending",
                    PaymentMethod = paymentMethod,
                    OrderDate = DateTime.Now
                };

                _context.orders.Add(order);
                await _context.SaveChangesAsync();

                // Add cart items as OrderItems
                foreach (var item in orderDto.OrderItems)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        ProductName = item.ProductName,
                        ProductImage = item.ProductImage
                    };
                    _context.orderItems.Add(orderItem);
                }

                // Add buy-now product as OrderItem if exists
                if (orderDto.BuyNowProduct != null)
                {
                    var buyNowOrderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = orderDto.BuyNowProduct.ProductId,
                        Quantity = orderDto.BuyNowProduct.Quantity,
                        UnitPrice = orderDto.BuyNowProduct.UnitPrice,
                        ProductName = orderDto.BuyNowProduct.ProductName,
                        ProductImage = orderDto.BuyNowProduct.ProductImage
                    };
                    _context.orderItems.Add(buyNowOrderItem);
                }

                await _context.SaveChangesAsync();

                // Clear cart after placing order
                var cart = await _context.carts.FirstOrDefaultAsync(c => c.UserId == userId);
                if (cart != null)
                {
                    var cartItemsToDelete = await _context.cartItems
                        .Where(ci => ci.CartId == cart.Id)
                        .ToListAsync();

                    _context.cartItems.RemoveRange(cartItemsToDelete);
                    await _context.SaveChangesAsync();
                }

                // Redirect to confirmation
                return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error placing order: " + ex.Message);
                return View("OrderDetails", orderDto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> OrderConfirmation(int orderId)
        {
            var order = await _context.orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            var product = await _context.products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
                return NotFound();

            var cart = await _context.carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = await _context.cartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cart.Id && ci.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = 1
                };
                _context.cartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Deskboard", "Deskboard");
        }
    }
}
