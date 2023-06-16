using Microsoft.EntityFrameworkCore;
using SportPlusShop.API.Models;

namespace SportPlusShop.API.Persistence;

public class SportsShopDbContext : DbContext
{
    public SportsShopDbContext(DbContextOptions<SportsShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(a => a.Category)
            .HasForeignKey(a => a.CategoryId);

        modelBuilder.Seed();
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();
}
