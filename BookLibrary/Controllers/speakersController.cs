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
    public class speakersController : ControllerBase
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        // GET: api/<speakersController>
        [HttpGet]
        public IEnumerable<speaker> Get()
        {
            var speakers = ds.Query<speaker>(speaker.Views.speakerL).ToList();
            return speakers;
        }

        // GET api/<speakersController>/5
        [HttpGet("{id}")]
        public speaker Get(Guid id)
        {
            try
            {
                speaker _speaker = new speaker();
                _speaker.SetExistObjectPrimaryKey(id);
                ds.LoadObject(_speaker);
                return _speaker;
            }
            catch
            {

            }
            return null;
        }

        // POST api/<speakersController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] speaker _speaker)
        {
            ds.UpdateObject(_speaker);//Добавить Объект
        }

        // PUT api/<speakersController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(Guid id, [FromBody] speaker _speaker)
        {
            try
            {
                speaker Speaker = new speaker();
                Speaker.SetExistObjectPrimaryKey(id);
                ds.LoadObject(Speaker);
                Speaker.SetProperties(_speaker);
                Speaker.SetStatus(ObjectStatus.Altered);
                ds.UpdateObject(Speaker);//Добавить Объект
            }
            catch
            {

            }
        }

        // DELETE api/<speakersController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(Guid id)
        {
            try
            {
                speaker Speaker = new speaker();
                Speaker.SetExistObjectPrimaryKey(id);
                ds.LoadObject(Speaker);

                Speaker.SetStatus(ObjectStatus.Deleted);
                ds.UpdateObject(Speaker);
            }
            catch
            {

            }
        }
    }
}
