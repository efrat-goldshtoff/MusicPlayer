using Microsoft.AspNetCore.Mvc;
using serverProject.Core.models;
using serverProject.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            var token = _authService.GenerateJwtToken(login.Name, login.Password);
            if (string.IsNullOrEmpty(token))
                return Unauthorized();
            return Ok(new { Token = token });
        }
    }
}
