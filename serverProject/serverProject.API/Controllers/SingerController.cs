using AutoMapper;
using serverProject.Core;
using serverProject.Core.DTOs;
using serverProject.Core.models;
using serverProject.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.API.Controllers
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

        [HttpGet]
        public async Task<IEnumerable<Singer>> GetAll()
        {
            return await _singerService.GetAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Singer>> GetById(int id)
        {
            var value = await _singerService.GetByIdAsync(id);
            if (value == null)
                return NotFound();
            return value;
        }


        [HttpPost]
        public async Task<ActionResult<Singer>> Post([FromBody] SingerDto value)
        {
            var s = await _singerService.AddAsync(value);
            return Ok(s);
        }


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
