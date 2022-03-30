using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Entity;

namespace ShoppingList.Data;

public class ShoppingListContext : DbContext
{
    public ShoppingListContext(DbContextOptions options) : base(options)
    {
    }

    public ShoppingListContext()
    {
    }

    public DbSet<ListItem> ListItems { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ListItem>()
          .HasOne<User>(l => l.User)
          .WithMany(u => u.ListItems)
          .HasForeignKey(l => l.UserId);

        modelBuilder.Entity<ListItem>()
          .HasOne<Product>(l => l.Product)
          .WithMany(p=> p.ListItems)
          .HasForeignKey(l => l.ProductId);

        base.OnModelCreating(modelBuilder);
    }
}
