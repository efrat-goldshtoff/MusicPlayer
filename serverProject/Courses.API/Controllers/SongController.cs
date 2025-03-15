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
    public class SongController : ControllerBase
    {
        private readonly ISingerService _context;
        //private readonly Mapping _mapping;
        private readonly IMapper _mapper;
        public SongController(ISingerService context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        // GET: api/<GuiderController>
        [HttpGet]
        public ActionResult Get()
        {
            var guiders = _context.GetList();
            var listDTO = _mapper.Map<IEnumerable<SingerDto>>(guiders);
            return Ok(listDTO);
        }

        // GET api/<GuiderController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var value = _context.GetById(id);
            var gDTO = _mapper.Map<SingerDto>(value);
            return Ok(gDTO);
        }

        // POST api/<GuiderController>
        [HttpPost]
        public void Post([FromBody] SongPostModel value)
        {
            var g = new Singer { Name = value.Name };
            _context.Add(g);
        }

        // PUT api/<GuiderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SongPostModel guide)
        {
            var g = new Singer { Name = guide.Name };
            _context.Update(id, g);
        }
        // PUT api/<GuiderController>/5
        [HttpPut]
        public void Put(int id, bool status)
        {
            _context.UpdateStatus(id, status);
        }
    }
}
