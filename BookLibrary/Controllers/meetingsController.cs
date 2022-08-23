using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using BookLibrary.Models;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class meetingsController : ControllerBase
    {
        IMeeting dataContext;
        public meetingsController(IMeeting dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET: api/<meetingsController>
        [HttpGet]
        public IEnumerable<meeting> Get()
        {
            return dataContext.getAll();
        }

        // GET api/<meetingsController>/5
        [HttpGet("{id}")]
        public meeting Get(Guid id)
        {
            return dataContext.getId(id);
        }

        // POST api/<meetingsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] MeetingModel _meeting)
        {
           var newMeeting = dataContext.add(_meeting);
           return Ok(new { __PrimaryKey = new { guid = newMeeting.__PrimaryKey } });
        }

        // PUT api/<meetingsController>/5
        [HttpPatch("{id}")]
        [Authorize]
        public void Patch(Guid id, object _meeting)
        {
            // dataContext.update(id, _meeting);
            var asd = 555;
        }

        // DELETE api/<meetingsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            dataContext.delete(id);
            return Ok(new { __PrimaryKey = new { guid = id } });
        }
    }
}
