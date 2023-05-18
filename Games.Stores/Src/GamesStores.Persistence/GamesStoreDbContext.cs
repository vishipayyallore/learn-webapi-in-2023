using GamesStores.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GamesStores.Persistence;

public class GamesStoreDbContext : DbContext
{
    public DbSet<Game> Games => Set<Game>();

    public GamesStoreDbContext(DbContextOptions<GamesStoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}