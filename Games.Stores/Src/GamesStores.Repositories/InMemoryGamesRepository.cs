using GamesStores.ApplicationCore.Interfaces;
using GamesStores.Data.Entities;

namespace GamesStores.Repositories;

public class InMemoryGamesRepository : IGamesRepository
{
    private readonly List<Game> games = GetDummyGames();

    public async Task<IReadOnlyCollection<Game>> GetAllGamesAsync()
    {
        return await Task.FromResult(games);
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        return await Task.FromResult(games.Find(game => game.Id == id));
    }

    public async Task CreateGameAsync(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;

        games.Add(game);

        await Task.CompletedTask;
    }

    public async Task UpdateGameAsync(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);

        games[index] = updatedGame;

        await Task.CompletedTask;
    }

    public async Task DeleteGameAsync(int id)
    {
        var index = games.FindIndex(game => game.Id == id);

        games.RemoveAt(index);

        await Task.CompletedTask;
    }

    private static List<Game> GetDummyGames()
    {
        return new List<Game>()
        {
            new Game { Id = 1, Name = "Street Fight II", Genre ="Fighting", Price = 18.00M, ReleaseDate = DateTime.Now, ImageUri = "https://placehold.co/100" },
            new Game { Id = 2, Name = "Final Fantasy XIV", Genre ="Roleplaying", Price = 19.00M, ReleaseDate = DateTime.Now, ImageUri = "https://placehold.co/100" },
            new Game { Id = 3, Name = "FIFA 2023", Genre ="Sports", Price = 20.00M, ReleaseDate = DateTime.Now, ImageUri = "https://placehold.co/100" }
        };
    }
}
