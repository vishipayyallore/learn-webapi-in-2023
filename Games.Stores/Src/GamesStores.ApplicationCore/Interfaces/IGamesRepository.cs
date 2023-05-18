using GamesStores.Data.Entities;

namespace GamesStores.ApplicationCore.Interfaces;

public interface IGamesRepository
{
    Task<IReadOnlyCollection<Game>> GetAllGamesAsync();

    Task<Game?> GetGameByIdAsync(int id);

    Task CreateGameAsync(Game game);

    Task UpdateGameAsync(Game updatedGame);

    Task DeleteGameAsync(int id);
}
