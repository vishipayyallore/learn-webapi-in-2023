using Microsoft.AspNetCore.Mvc;
using Music.API.Entities;

namespace Music.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SongsController : ControllerBase
{
    private static readonly List<Song> _songs = new()
    {
        new Song { Id = Guid.NewGuid(), Title = "Willow", Language = "English"},

        new Song { Id = Guid.NewGuid(), Title = "After Glow", Language = "English"}
    };

    [HttpGet]
    public IReadOnlyCollection<Song> GetAllSongs()
    {
        return _songs;
    }

    [HttpPost]
    public Song AddSong(Song song)
    {
        _songs.Add(song);

        return song;
    }

}
