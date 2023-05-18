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

    public IReadOnlyCollection<Game> GetAllGamesAsync()
    {
        return _gamesStoreDbContext.Games.AsNoTracking().ToList();
    }

    public Game? GetGameByIdAsync(int id)
    {
        return _gamesStoreDbContext.Games.Find(id);
    }

    public void CreateGameAsync(Game game)
    {
        _gamesStoreDbContext.Games.Add(game);

        _gamesStoreDbContext.SaveChanges();
    }

    public void UpdateGameAsync(Game updatedGame)
    {
        _gamesStoreDbContext.Update(updatedGame);

        _gamesStoreDbContext.SaveChanges();
    }

    public void DeleteGameAsync(int id)
    {
        _gamesStoreDbContext.Games
            .Where(game => game.Id == id)
            .ExecuteDelete();
    }

}
