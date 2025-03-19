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
