using AutoMapper;
using serverProject.Core;
using serverProject.Core.DTOs;
using serverProject.Core.models;
using serverProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        public SongController(ISongService context)
        {
            _songService = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Song>> GetAll()
        {
            return await _songService.GetAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetById(int id)
        {
            Song song = await _songService.GetByIdAsync(id);
            if (song == null)
                return NotFound();
            return song;
        }

        [HttpGet("byGenre/{genre}")]
        public async Task<ActionResult<IEnumerable<Song>>> GetByGenre(string genre)
        {
            var songs = await _songService.GetSongsByGenreAsync(genre); // Assuming GetSongsByGenreAsync exists in ISongService
            if (songs == null || !songs.Any())
                return NotFound();
            return Ok(songs);
        }

        [HttpGet("searchByAI")]
        public async Task<ActionResult<IEnumerable<Song>>> SearchSongsByAI([FromQuery] string query)
        {
            // This will call an AI service to get relevant genres/keywords
            // and then filter songs based on those.
            // For now, it will be a placeholder.
            return Ok(await _songService.GetAllAsync()); // Placeholder
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Song>> Post([FromBody] SongDto value)
        {

            Song s = await _songService.AddAsync(value);
            return Ok(s);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SongDto song)
        {
            Song s = await _songService.UpdateAsync(id, song);
            if (s == null)
                return NotFound();
            return Ok(s);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _songService.DeleteAsync(id);
            return NoContent();
        }
    }
}
