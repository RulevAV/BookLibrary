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
    public class reportsController : ControllerBase
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        // GET: api/<reportsController>
        [HttpGet]
        public IEnumerable<report> Get()
        {
            var reports = ds.Query<report>(report.Views.reportL).ToList();
            return reports;
        }

        // GET api/<reportsController>/5
        [HttpGet("{id}")]
        public report Get(Guid id)
        {
            try
            {
                report _report = new report();
                _report.SetExistObjectPrimaryKey(id);
                ds.LoadObject(_report);
                return _report;
            }
            catch
            {

            }
            return null;
        }

        // POST api/<reportsController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] report _report)
        {
            var _book = new book();
            var _meeting = new meeting();
            var _speaker = new speaker();

            //_book.reports.Add(_report);
            //_meeting.reports.Add(_report);
            //_speaker.reports.Add(_report);

            //var p = new DataObject[] { _report, _book, _meeting , _speaker };

            ds.UpdateObject(_report);//Добавить Объект
        }

        // PUT api/<reportsController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] report _report)
        {
            try
            {
                report Report = new report();
                Report.SetExistObjectPrimaryKey(id);
                ds.LoadObject(Report);
                Report.SetProperties(_report);
                Report.SetStatus(ObjectStatus.Altered);
                ds.UpdateObject(Report);//Добавить Объект
            }
            catch
            {

            }
        }

        // DELETE api/<reportsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(Guid id)
        {
            try
            {
                report Report = new report();
                Report.SetExistObjectPrimaryKey(id);
                ds.LoadObject(Report);

                Report.SetStatus(ObjectStatus.Deleted);
                ds.UpdateObject(Report);
            }
            catch
            {

            }
        }
    }
}
