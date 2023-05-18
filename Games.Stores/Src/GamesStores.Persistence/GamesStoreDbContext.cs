using GamesStores.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStores.Persistence;


public class GamesStoreDbContext : DbContext
{
    public GamesStoreDbContext(DbContextOptions<GamesStoreDbContext> options) : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}