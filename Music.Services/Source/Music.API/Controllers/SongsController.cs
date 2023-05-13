// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Data.Dtos;
using Music.Data.Entities;
using Music.Persistence;

namespace Music.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SongsController : ControllerBase
{
    private readonly MusicDbContext _musicDbContext;
    const string notFoundMessage = "No record was found for the given id";

    public SongsController(MusicDbContext dbContext)
    {
        _musicDbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    // GET: api/<SongsController>
    [HttpGet]
    public async Task<IActionResult> GetSongsAsync()
    {
        return Ok(await _musicDbContext.Songs.ToListAsync());
    }

    // GET api/<SongsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSongByIdAsync(Guid id)
    {
        return await _musicDbContext.Songs.FindAsync(id) is Song song ?
            Ok(song) :
            NotFound($"{notFoundMessage} {id}");
    }

    // POST api/<SongsController>
    [HttpPost]
    public async Task<IActionResult> AddSongAsync([FromBody] AddSongDto newSong)
    {
        var song = new Song { Language = newSong.Language, Title = newSong.Title };

        await _musicDbContext.Songs.AddAsync(song);

        await _musicDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSongByIdAsync), new { id = song.Id }, song);
    }

    // PUT api/<SongsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> EditSongByIdAsync(Guid id, [FromBody] Song updatedSong)
    {
        var song = await _musicDbContext.Songs.FindAsync(id);

        if (song is null)
        {
            return NotFound($"{notFoundMessage} {id}");
        }

        song.Title = updatedSong.Title;
        song.Language = updatedSong.Language;

        await _musicDbContext.SaveChangesAsync();

        return Ok(song);
    }

    // DELETE api/<SongsController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSongByIdAsync(Guid id)
    {
        var song = await _musicDbContext.Songs.FindAsync(id);

        if (song is null)
        {
            return NotFound($"{notFoundMessage} {id}");
        }

        _musicDbContext.Songs.Remove(song);

        await _musicDbContext.SaveChangesAsync();

        return NoContent();
    }
}
