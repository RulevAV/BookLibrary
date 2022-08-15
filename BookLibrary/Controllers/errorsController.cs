using BookLibrary.Entities;
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
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        // GET: api/<errorsController>
        [HttpGet]
        public IEnumerable<error> Get()
        {
            var errors = ds.Query<error>(error.Views.errorL).ToList();
            return errors;
        }

        // GET api/<errorsController>/5
        [HttpGet("{id}")]
        public error Get(Guid id)
        {
            try
            {
                error _error = new error();
                _error.SetExistObjectPrimaryKey(id);
                ds.LoadObject(_error);
                return _error;
            }
            catch
            {

            }
            return null;
        }

        // POST api/<errorsController>
        [HttpPost]
        public void Post([FromBody] error _error)
        {
            ds.UpdateObject(_error);//Добавить Объект
        }

    }
}
