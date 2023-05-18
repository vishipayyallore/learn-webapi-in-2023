using GamesStores.ApplicationCore.Interfaces;
using GamesStores.Data.Entities;
using GamesStores.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GamesStores.Repositories;

public class GamesRepository : IGamesRepository
{
    private readonly GamesStoreDbContext _gamesStoreDbContext;

    public GamesRepository(GamesStoreDbContext gamesStoreDbContext)
    {
        _gamesStoreDbContext = gamesStoreDbContext ?? throw new ArgumentNullException(nameof(gamesStoreDbContext));
    }

    public async Task<IReadOnlyCollection<Game>> GetAllGamesAsync()
    {
        return await _gamesStoreDbContext.Games.AsNoTracking().ToListAsync();
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        return await _gamesStoreDbContext.Games.FindAsync(id);
    }

    public async Task CreateGameAsync(Game game)
    {
        _gamesStoreDbContext.Games.Add(game);

        await _gamesStoreDbContext.SaveChangesAsync();
    }

    public async Task UpdateGameAsync(Game updatedGame)
    {
        _gamesStoreDbContext.Update(updatedGame);

        await _gamesStoreDbContext.SaveChangesAsync();
    }

    public async Task DeleteGameAsync(int id)
    {
        await _gamesStoreDbContext.Games
                .Where(game => game.Id == id)
                .ExecuteDeleteAsync();
    }

}
