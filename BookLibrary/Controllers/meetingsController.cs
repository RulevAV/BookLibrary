using BookLibrary.Entities;
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
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        // GET: api/<meetingsController>
        [HttpGet]
        public IEnumerable<meeting> Get()
        {
            var meetings = ds.Query<meeting>(meeting.Views.meetingL).ToList();
            return meetings;
        }

        // GET api/<meetingsController>/5
        [HttpGet("{id}")]
        public meeting Get(Guid id)
        {
            try
            {
                meeting _meeting = new meeting();
                _meeting.SetExistObjectPrimaryKey(id);
                ds.LoadObject(_meeting);
                return _meeting;
            }
            catch
            {

            }
            return null;
        }

        // POST api/<meetingsController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] meeting _meeting)
        {
            ds.UpdateObject(_meeting);//Добавить Объект
        }

        // PUT api/<meetingsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(Guid id, [FromBody] meeting _meeting)
        {
            try
            {
                meeting Meeting = new meeting();
                Meeting.SetExistObjectPrimaryKey(id);
                ds.LoadObject(Meeting);
                Meeting.SetProperties(_meeting);
                Meeting.SetStatus(ObjectStatus.Altered);
                ds.UpdateObject(Meeting);//Добавить Объект
            }
            catch
            {

            }
        }

        // DELETE api/<meetingsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(Guid id)
        {
            try
            {
                meeting Meeting = new meeting();
                Meeting.SetExistObjectPrimaryKey(id);
                ds.LoadObject(Meeting);

                Meeting.SetStatus(ObjectStatus.Deleted);
                ds.UpdateObject(Meeting);
            }
            catch
            {

            }
        }
    }
}
