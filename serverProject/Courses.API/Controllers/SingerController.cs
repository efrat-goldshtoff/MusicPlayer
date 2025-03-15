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
        private readonly IUserService _context;
        //private readonly Mapping _mapping;
        private readonly IMapper _mapper;
        public SingerController(IUserService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public ActionResult Get()
        {
            var singers = _context.GetList();
            var listDTO = _mapper.Map<IEnumerable<SongDto>>(singers);
            return Ok(listDTO);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var value = _context.GetById(id);
            var cDTO = _mapper.Map<SongDto>(value);
            return Ok(cDTO);
        }

        // POST api/<CoursesController>
        [HttpPost]
        public void Post([FromBody] SingerPostModel value)
        {
            var c = new Song
            {
                Subject = value.Subject,
                CurrentCount = value.CurrentCount,
                MaxCount = value.MaxCount,
                GuideId = value.GuideId,
                Day = value.Day
            };
            _context.Add(c);
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SingerPostModel value)
        {
            var c = new Song
            {
                Subject = value.Subject,
                CurrentCount = value.CurrentCount,
                MaxCount = value.MaxCount,
                GuideId = value.GuideId,
                Day = value.Day
            };
            _context.Update(id, c);

        }
        [HttpPut]
        public void Put(int id, bool status)
        {
            _context.UpdateStatus(id, status);
        }
    }
}
