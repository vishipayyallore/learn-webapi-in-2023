namespace GamesStores.ApplicationCore.Interfaces;

public interface IGamesRepository
{
    void CreateGame(Game game);

    void DeleteGame(int id);

    IReadOnlyCollection<Game> GetAllGames();

    Game? GetGameById(int id);

    void UpdateGame(Game updatedGame);
}
