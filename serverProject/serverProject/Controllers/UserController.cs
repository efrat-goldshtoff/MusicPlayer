using AutoMapper;
//using serverProject.API.models;
using serverProject.Core;
using serverProject.Core.DTOs;
using serverProject.Core.models;
using serverProject.Core.Services;
//using serverProject.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService context)
        {
            _userService = context;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserDto value)
        {
            User user = await _userService.AddAsync(value);
            return Ok(user);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto value)
        {
            User user = await _userService.UpdateAsync(id, value);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        // PUT api/<StudentsController>/5
        [HttpPut]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
