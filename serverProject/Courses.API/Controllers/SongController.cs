﻿using AutoMapper;
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
        private readonly ISongtService _songService;
        public SongController(ISongtService context)
        {
            _songService = context;

        }
        // GET: api/<GuiderController>
        [HttpGet]
        public async Task<IEnumerable<Song>> GetAll()
        {
            return await _songService.GetAllAsync();
        }

        // GET api/<GuiderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetById(int id)
        {
            Song song = await _songService.GetByIdAsync(id);
            if (song == null)
                return NotFound();
            return song;
        }

        // POST api/<GuiderController>
        [HttpPost]
        public async Task<ActionResult<Song>> Post([FromBody] SongDto value)
        {

            Song s = await _songService.AddAsync(value);
            return Ok(s);
        }

        // PUT api/<GuiderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SongDto song)
        {
            Song s = await _songService.UpdateAsync(id, song);
            if (s == null)
                return NotFound();
            return Ok(s);
        }
        // PUT api/<GuiderController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _songService.DeleteAsync(id);
            return NoContent();
        }
    }
}
