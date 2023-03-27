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
    public Song AddSong([FromBody] Song song)
    {
        _songs.Add(song);

        return song;
    }

    [HttpPut("{id}")]
    public Song UpdateSong(Guid id, [FromBody] Song song)
    {
        var index = _songs.FindIndex(x => x.Id == id);
        _songs[index] = song;

        return song;
    }

}
