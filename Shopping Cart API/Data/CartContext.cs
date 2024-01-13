using Microsoft.EntityFrameworkCore;
using Shopping_Cart_API.Models;

namespace Shopping_Cart_API.Data;

public class CartContext: DbContext 
{
    public CartContext(DbContextOptions<CartContext> options): base(options)
    {

    }
    public DbSet<Item>Items { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<ItemUser>ItemUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemUser>()
             .HasKey(iu => new { iu.ItemId, iu.UserId });
        modelBuilder.Entity<ItemUser>()
            .HasOne(iu => iu.User)
            .WithMany(u => u.ItemUsers)
            .HasForeignKey(iu => iu.UserId);
        modelBuilder.Entity<ItemUser>()
            .HasOne(iu => iu.Item)
            .WithMany(i => i.ItemUsers)
            .HasForeignKey(iu => iu.ItemId);
        modelBuilder.Entity<ItemUser>()
            .Property(iu => iu.Amount)
            .IsRequired();
    }
}
