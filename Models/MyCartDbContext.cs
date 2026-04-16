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
        public DbSet<UserProfile> userProfiles { get; set; }
        public DbSet<UserAddresses> userAddresses { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public MyCartDbContext(DbContextOptions<MyCartDbContext> options) : base(options)
        {

        }

       
    }
}
