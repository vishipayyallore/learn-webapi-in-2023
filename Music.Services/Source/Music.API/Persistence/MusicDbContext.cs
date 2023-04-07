using Microsoft.EntityFrameworkCore;
using Music.API.Data.Entities;

namespace Music.API.Persistence;

public class MusicDbContext : DbContext
{

    public MusicDbContext(DbContextOptions<MusicDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Song> Songs => Set<Song>();

}
