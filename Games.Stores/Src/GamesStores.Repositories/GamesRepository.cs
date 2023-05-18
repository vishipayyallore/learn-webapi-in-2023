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

    public IReadOnlyCollection<Game> GetAllGames()
    {
        return _gamesStoreDbContext.Games.AsNoTracking().ToList();
    }

    public Game? GetGameById(int id)
    {
        return _gamesStoreDbContext.Games.Find(id);
    }

    public void CreateGame(Game game)
    {
        _gamesStoreDbContext.Games.Add(game);

        _gamesStoreDbContext.SaveChanges();
    }

    public void UpdateGame(Game updatedGame)
    {
        _gamesStoreDbContext.Update(updatedGame);

        _gamesStoreDbContext.SaveChanges();
    }

    public void DeleteGame(int id)
    {
        _gamesStoreDbContext.Games
            .Where(game => game.Id == id)
            .ExecuteDelete();
    }

}
