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
    public class UserController : ControllerBase
    {
        private readonly ISongtService _context;
        private readonly IMapper _mapper;
        public UserController(ISongtService context, IMapper mappre)
        {
            _context = context;
            _mapper = mappre;

        }
        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult Get()
        {
            var studs = _context.GetList();
            var listDTO = _mapper.Map<IEnumerable<UserDto>>(studs);
            return Ok(listDTO);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var value = _context.GetById(id);
            var sDTO = _mapper.Map<UserDto>(value);
            return Ok(sDTO);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] UserPostModel value)
        {
            var s = new User { Name = value.Name };
            _context.Add(s);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserPostModel value)
        {
            var s = new User { Name = value.Name };
            _context.Update(id, s);
        }
        // PUT api/<StudentsController>/5
        [HttpPut]
        public void Put(int id, bool status)
        {
            _context.UpdateStatus(id, status);
        }
    }
}
