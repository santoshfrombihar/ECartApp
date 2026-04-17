using ECartApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECartApp.Data
{
    public static class EntityConfiguration
    {
        public static void ConfigureEntities(this ModelBuilder modelBuilder)
        {
            // Configure Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.Property(p => p.ProductName).HasMaxLength(200).IsRequired();
                entity.Property(p => p.ProductDescription).HasMaxLength(1000);
                entity.Property(p => p.ProductImage).HasMaxLength(500);
                entity.Property(p => p.Price).HasPrecision(18, 2).HasDefaultValue(0);
                
                entity.HasOne(p => p.Type)
                    .WithMany()
                    .HasForeignKey(p => p.TypeId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(p => p.Color)
                    .WithMany()
                    .HasForeignKey(p => p.ColorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(p => p.OrderItems)
                    .WithOne(oi => oi.Product)
                    .HasForeignKey(oi => oi.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(p => p.ProductName);
                entity.HasIndex(p => p.Price);
            });

            // Configure User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(u => u.Email).HasMaxLength(255).IsRequired();
                entity.Property(u => u.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(u => u.LastName).HasMaxLength(100).IsRequired();
                entity.Property(u => u.Role).HasMaxLength(50).HasDefaultValue("Customer");

                entity.HasIndex(u => u.Email).IsUnique();

                entity.HasOne(u => u.UserProfile)
                    .WithOne(up => up.User)
                    .HasForeignKey<UserProfile>(up => up.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.UserAddresses)
                    .WithOne(ua => ua.User)
                    .HasForeignKey(ua => ua.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.Carts)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.Orders)
                    .WithOne(o => o.User)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Cart
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Carts");
                entity.HasKey(c => c.Id);

                entity.HasMany(c => c.CartItems)
                    .WithOne(ci => ci.Cart)
                    .HasForeignKey(ci => ci.CartId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure CartItem
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItems");
                entity.Property(ci => ci.Quantity).HasDefaultValue(1);

                entity.HasOne(ci => ci.Product)
                    .WithMany()
                    .HasForeignKey(ci => ci.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.Property(o => o.OrderNumber).HasMaxLength(50).IsRequired();
                entity.Property(o => o.Status).HasMaxLength(50).HasDefaultValue("Pending");
                entity.Property(o => o.PaymentMethod).HasMaxLength(50).HasDefaultValue("UPI");
                entity.Property(o => o.TotalAmount).HasPrecision(18, 2);
                entity.Property(o => o.DiscountAmount).HasPrecision(18, 2);
                entity.Property(o => o.GSTAmount).HasPrecision(18, 2);
                entity.Property(o => o.FinalAmount).HasPrecision(18, 2);
                entity.Property(o => o.CouponDiscount).HasPrecision(18, 2).HasDefaultValue(0);

                entity.HasMany(o => o.OrderItems)
                    .WithOne(oi => oi.Order)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(o => o.OrderNumber).IsUnique();
                entity.HasIndex(o => o.UserId);
                entity.HasIndex(o => o.OrderDate);
            });

            // Configure OrderItem (Many-to-Many through junction table)
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems");
                entity.Property(oi => oi.UnitPrice).HasPrecision(18, 2);
                entity.Property(oi => oi.ProductName).HasMaxLength(200);
                entity.Property(oi => oi.ProductImage).HasMaxLength(500);

                entity.HasOne(oi => oi.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(oi => oi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure UserProfile
            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfiles");
                entity.Property(up => up.PhoneNumber).HasMaxLength(20);
                entity.Property(up => up.Gender).HasMaxLength(20);
            });

            // Configure UserAddresses
            modelBuilder.Entity<UserAddresses>(entity =>
            {
                entity.ToTable("UserAddresses");
                entity.Property(ua => ua.Address).HasMaxLength(500);
                entity.Property(ua => ua.City).HasMaxLength(100);
                entity.Property(ua => ua.State).HasMaxLength(100);
                entity.Property(ua => ua.District).HasMaxLength(100);
                entity.Property(ua => ua.ContactNumber).HasMaxLength(20);
            });
        }
    }
}