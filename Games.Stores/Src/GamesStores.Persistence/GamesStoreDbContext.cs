using Microsoft.EntityFrameworkCore;

namespace GamesStores.Persistence
{

    public class GamesStoreDbContext : DbContext
    {

        public GamesStoreDbContext(DbContextOptions<GamesStoreDbContext> options) : base(options)
        {
        }


        // public DbSet<Game> MyProperty { get; set; }
    }

}