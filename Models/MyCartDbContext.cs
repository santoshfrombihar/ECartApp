using ECartApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ECartApp.Models
{
    public class MyCartDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Login> login { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductColor> productsColor { get; set; }
        public DbSet<ProductType> productsType { get; set; }
        public DbSet<UserProfile> userprofiles { get; set; }
        public DbSet<UserAddresses> userAddresses { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }

        public MyCartDbContext(DbContextOptions<MyCartDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Apply Fluent API configurations
            modelBuilder.ConfigureEntities();
        }
    }
}
