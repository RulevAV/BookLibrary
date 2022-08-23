using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using BookLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class speakersController : ControllerBase
    {
        ISpeaker dataContext;

        public speakersController(ISpeaker dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET
        [HttpGet]
        public IEnumerable<speaker> GetAllSpeakers()
        {
            return dataContext.getAll();
        }

        // GET 
        [HttpGet("{id}")]
        public speaker Get(Guid id)
        {
            return dataContext.getId(id);
        }

        // POST 
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] speaker _speaker)
        {
            dataContext.add(_speaker);
            return Ok(new { __PrimaryKey = new { guid = _speaker.__PrimaryKey } });

        }

        // Patch 
        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult Patch(Guid id, [FromBody] SpeakerModel _speaker)
        {
           dataContext.update( id, _speaker);
           return Ok(new { __PrimaryKey = new { guid = id } });
        }

        // DELETE 
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            dataContext.delete(id);
            return Ok(new { __PrimaryKey = new { guid = id } });
        }
    }
}
