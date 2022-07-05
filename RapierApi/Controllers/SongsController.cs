using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapierApi.Data;
using RapierApi.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace RapierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song song)
        {
            song.UploadedDate = DateTime.Now;
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            var songs = await (from song in _dbContext.Songs
                               select new
                               {
                                   song.Id,
                                   song.Title,
                                   song.Duration
                               }).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FeaturedSongs()
        {
            var songs = await (from song in _dbContext.Songs
                               where song.IsFeatured == true
                               select new
                               {
                                   song.Id,
                                   song.Title,
                                   song.Duration
                               }).ToListAsync();
            return Ok(songs);
        }
    }
}
