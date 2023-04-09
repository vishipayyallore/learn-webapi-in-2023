using Microsoft.EntityFrameworkCore;

namespace Music.API.Persistence;

public class MusicDbContext : DbContext
{

    public MusicDbContext(DbContextOptions<MusicDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Song> Songs => Set<Song>();

}
