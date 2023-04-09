using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.API.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Music.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly MusicDbContext _musicDbContext;

        public SongsController(MusicDbContext dbContext)
        {
            _musicDbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // GET: api/<SongsController>
        [HttpGet]
        public async Task<IReadOnlyCollection<Song>> GetSongsAsync()
        {
            return await _musicDbContext.Songs.ToListAsync();
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSongByIdAsync(Guid id)
        {
            return await _musicDbContext.Songs.FindAsync(id) is Song song ? Ok(song) : NotFound();
        }

        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> AddSongAsync([FromBody] Song song)
        {
            await _musicDbContext.Songs.AddAsync(song);
            await _musicDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSongByIdAsync), new { id = song.Id }, song);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void EditSongByIdAsync(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void DeleteSongByIdAsync(int id)
        {
        }
    }
}
