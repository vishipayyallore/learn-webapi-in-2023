using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.API.Data.Entities;
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
        public async Task<IReadOnlyCollection<Song>> Get()
        {
            return await _musicDbContext.Songs.ToListAsync();
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SongsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
