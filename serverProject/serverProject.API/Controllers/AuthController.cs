using Microsoft.AspNetCore.Mvc;
using serverProject.Core.DTOs;
using serverProject.Core.models;
using serverProject.Core.Services;
using serverProject.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IUserService _userService; // Inject UserService for registration

        public AuthController(AuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginM login)
        {
            var token = _authService.GenerateJwtToken(login.Name, login.Password);
            if (string.IsNullOrEmpty(token))
                return Unauthorized();
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto registerDto) // Use UserDto for registration
        {
            // Check if user with this email or name already exists
            var existingUser = await _userService.GetUserByEmailAsync(registerDto.Email); // Need to add this method
            if (existingUser != null)
            {
                return BadRequest("User with this email already exists.");
            }
            existingUser = await _userService.GetUserByNameAsync(registerDto.Name); // Need to add this method
            if (existingUser != null)
            {
                return BadRequest("User with this name already exists.");
            }

            // Default role for new registrations (e.g., "User")
            registerDto.Role = "User";
            var newUser = await _userService.AddAsync(registerDto); // Add user to DB
            if (newUser == null)
            {
                return StatusCode(500, "Failed to register user.");
            }

            // Automatically log in after registration, or just return success
            var token = _authService.GenerateJwtToken(newUser.Name, registerDto.Password); // Use the provided password for token generation
            if (string.IsNullOrEmpty(token))
            {
                return StatusCode(500, "User registered but failed to generate token.");
            }
            return Ok(new { Token = token, User = newUser }); // Return token and user details
        }
        //private readonly AuthService _authService;
        //public AuthController(AuthService authService)
        //{
        //    _authService = authService;
        //}

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] LoginM login)
        //{
        //    var token = _authService.GenerateJwtToken(login.Name, login.Password);
        //    if (string.IsNullOrEmpty(token))
        //        return Unauthorized();
        //    return Ok(new { Token = token });
        //}
    }
}
