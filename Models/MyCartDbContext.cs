using Microsoft.EntityFrameworkCore;

namespace ECartApp.Models
{
    public class MyCartDbContext : DbContext
    {
        public DbSet<Register> register { get; set; }
        public DbSet<Login> login { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductColor> productsColor { get; set; }
        public DbSet<ProductType> productsType { get; set; }
        public MyCartDbContext(DbContextOptions<MyCartDbContext> options) : base(options)
        {

        }

       
    }
}
