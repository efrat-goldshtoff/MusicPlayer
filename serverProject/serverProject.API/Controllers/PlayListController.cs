using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using serverProject.Core.DTOs;
using serverProject.Core.models;
using serverProject.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // All playlist actions require authentication
    public class PlayListController : ControllerBase
    {
        private readonly IPlayListService _playlistService;

        public PlayListController(IPlayListService playlistService)
        {
            _playlistService = playlistService;
        }

        // Helper to get current user's ID
        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userIdClaim != null ? int.Parse(userIdClaim) : -1; // Or throw exception
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayList>>> Get()
        {
            var userId = GetCurrentUserId();
            if (userId == -1) return Unauthorized();
            var playlists = await _playlistService.GetPlaylistsByUserIdAsync(userId);
            return Ok(playlists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayList>> Get(int id)
        {
            var userId = GetCurrentUserId();
            if (userId == -1) return Unauthorized();

            var playlist = await _playlistService.GetByIdAsync(id);
            if (playlist == null || playlist.UserId != userId)
            {
                return NotFound();
            }
            return Ok(playlist);
        }

        [HttpPost]
        public async Task<ActionResult<PlayList>> Post([FromBody] PlayListDto playlistDto)
        {
            var userId = GetCurrentUserId();
            if (userId == -1) return Unauthorized();

            playlistDto.UserId = userId; // Ensure playlist is assigned to the current user
            var newPlaylist = await _playlistService.AddAsync(playlistDto);
            return CreatedAtAction(nameof(Get), new { id = newPlaylist.Id }, newPlaylist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlayListDto playlistDto)
        {
            var userId = GetCurrentUserId();
            if (userId == -1) return Unauthorized();

            var existingPlaylist = await _playlistService.GetByIdAsync(id);
            if (existingPlaylist == null || existingPlaylist.UserId != userId)
            {
                return NotFound();
            }

            var updatedPlaylist = await _playlistService.UpdateAsync(id, playlistDto);
            if (updatedPlaylist == null)
                return NotFound();
            return Ok(updatedPlaylist);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetCurrentUserId();
            if (userId == -1) return Unauthorized();

            var existingPlaylist = await _playlistService.GetByIdAsync(id);
            if (existingPlaylist == null || existingPlaylist.UserId != userId)
            {
                return NotFound();
            }

            await _playlistService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{playlistId}/addsong/{songId}")]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            var userId = GetCurrentUserId();
            if (userId == -1) return Unauthorized();

            var existingPlaylist = await _playlistService.GetByIdAsync(playlistId);
            if (existingPlaylist == null || existingPlaylist.UserId != userId)
            {
                return NotFound("Playlist not found or not owned by user.");
            }

            await _playlistService.AddSongToPlaylistAsync(playlistId, songId);
            return Ok();
        }

        [HttpDelete("{playlistId}/removesong/{songId}")]
        public async Task<IActionResult> RemoveSongFromPlaylist(int playlistId, int songId)
        {
            var userId = GetCurrentUserId();
            if (userId == -1) return Unauthorized();

            var existingPlaylist = await _playlistService.GetByIdAsync(playlistId);
            if (existingPlaylist == null || existingPlaylist.UserId != userId)
            {
                return NotFound("Playlist not found or not owned by user.");
            }
            await _playlistService.RemoveSongFromPlaylistAsync(playlistId, songId);
            return Ok();
        }

    }
}
