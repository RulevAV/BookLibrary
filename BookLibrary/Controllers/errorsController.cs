using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class errorsController : ControllerBase
    {
        IError dataContext;
        public errorsController(IError dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET: api/<errorsController>
        [HttpGet]
        public IEnumerable<error> Get()
        {
            return dataContext.getAll();
        }

        // GET api/<errorsController>/5
        [HttpGet("{id}")]
        public error Get(Guid id)
        {
            return dataContext.getId(id);
        }

        // POST api/<errorsController>
        [HttpPost]
        public void Post([FromBody] error _error)
        {
            dataContext.add(_error);
        }
    }
}
