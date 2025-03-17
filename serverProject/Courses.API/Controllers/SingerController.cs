using AutoMapper;
using Courses.API.models;
using Courses.Core;
using Courses.Core.DTOs;
using Courses.Core.models;
using Courses.Core.Services;
using Courses.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingerController : ControllerBase
    {
        private readonly ISingerService _singerService;
        public SingerController(ISingerService context)
        {
            _singerService = context;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<IEnumerable<Singer>> GetAll()
        {
            return await _singerService.GetAllAsync();
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Singer>> GetById(int id)
        {
            var value = await _singerService.GetByIdAsync(id);
            if (value == null)
                return NotFound();
            return value;
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult<Singer>> Post([FromBody] SingerDto value)
        {
            var s = await _singerService.AddAsync(value);
            return Ok(s);
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SingerDto value)
        {
            Singer s = await _singerService.UpdateAsync(id, value);
            if (s == null)
                return NotFound();
            return Ok(s);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _singerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
