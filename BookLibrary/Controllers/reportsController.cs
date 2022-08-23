using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
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
    public class reportsController : ControllerBase
    {
        IReport dataContext;
        public reportsController(IReport dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET
        [HttpGet]
        public IEnumerable<report> Get()
        {
            return dataContext.getAll();
        }

        // GET
        [HttpGet("{id}")]
        public report Get(Guid id)
        {
            return dataContext.getId(id);
        }

        // POST
        [HttpPost]
        [Authorize]
        public IActionResult Post(object _report)
        {
            var _book = new book();
            var _meeting = new meeting();
            var _speaker = new speaker();

            //_book.reports.Add(_report);
            //_meeting.reports.Add(_report);
            //_speaker.reports.Add(_report);

            //var p = new DataObject[] { _report, _book, _meeting , _speaker };

           // dataContext.add(_report);
            return Ok();
        }

        // PUT
        [HttpPatch("{id}")]
        public IActionResult Putch(Guid id, object _report)
        {
           // dataContext.update(id, _report);
           // return Ok(new { __PrimaryKey = new { guid = id } });
           return Ok();
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
