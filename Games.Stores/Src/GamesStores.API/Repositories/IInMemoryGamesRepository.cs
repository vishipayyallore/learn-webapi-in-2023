using GamesStores.API.Data.Entities;

namespace GamesStores.API.Repositories;

public interface IGamesRepository
{
    void CreateGame(Game game);

    void DeleteGame(int id);

    IReadOnlyCollection<Game> GetAllGames();

    Game? GetGameById(int id);

    void UpdateGame(Game updatedGame);
}
