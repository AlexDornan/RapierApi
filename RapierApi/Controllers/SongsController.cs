using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapierApi.Data;
using RapierApi.Models;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            song.UploadedDate = DateTime.Now;
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
