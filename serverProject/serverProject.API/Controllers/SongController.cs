using AutoMapper;
using serverProject.Core;
using serverProject.Core.DTOs;
using serverProject.Core.models;
using serverProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using serverProject.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly AwsS3Service _s3Service;

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
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Search query cannot be empty.");
            }
            var songs = await _songService.SearchSongsByAIAsync(query);
            if (songs == null || !songs.Any())
            {
                return NotFound("No songs found for the given AI query.");
            }
            return Ok(songs);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Consumes("multipart/form-data")] // Allow file upload
        public async Task<ActionResult<Song>> Post([FromForm] SongDto value, IFormFile audioFile)
        {
            if (audioFile == null || audioFile.Length == 0)
            {
                return BadRequest("Audio file is required.");
            }

            // Upload file to S3
            var audioUrl = await _s3Service.UploadFileAsync(audioFile);

            // Update DTO with the S3 URL
            value.Link = audioUrl;

            Song s = await _songService.AddAsync(value);
            return Ok(s);
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public async Task<ActionResult<Song>> Post([FromBody] SongDto value)
        //{

        //    Song s = await _songService.AddAsync(value);
        //    return Ok(s);
        //}

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
