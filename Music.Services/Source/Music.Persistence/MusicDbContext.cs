using Microsoft.EntityFrameworkCore;
using Music.Data.Entities;

namespace Music.Persistence;

public class MusicDbContext : DbContext
{

    public MusicDbContext(DbContextOptions<MusicDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Song> Songs => Set<Song>();

}
