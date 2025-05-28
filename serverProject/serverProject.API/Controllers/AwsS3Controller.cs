using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using serverProject.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Only admins can upload/delete
    public class AwsS3Controller : ControllerBase
    {
        private readonly IAwsS3Service _s3Service;
        private readonly ISongService _songService; // To update song link in DB

        public AwsS3Controller(IAwsS3Service s3Service, ISongService songService)
        {
            _s3Service = s3Service;
            _songService = songService;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            try
            {
                var fileUrl = await _s3Service.UploadFileAsync(file);
                // Optionally, you can now save this fileUrl to your Song model in the database
                return Ok(new { Url = fileUrl });
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFile([FromQuery] string fileUrl)
        {
            try
            {
                // Before deleting from S3, you might want to remove the link from the song in your DB
                // This logic depends on whether you want to prevent dangling links.
                var deleted = await _s3Service.DeleteFileAsync(fileUrl);
                if (!deleted)
                {
                    return NotFound("File not found or could not be deleted.");
                }
                return Ok("File deleted successfully.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
