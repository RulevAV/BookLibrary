using BookLibrary.Entities;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using ICSSoft.STORMNET.KeyGen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        // GET: api/<booksController>
        [HttpGet]
        public IEnumerable<book> Get()
        {
            var books = ds.Query<book>(book.Views.bookL).ToList();
            return books;
        }

        // GET api/<booksController>/5
        [HttpGet("{id}")]
        public book Get(Guid id)
        {
            try
            {
                book _book = new book();
                _book.SetExistObjectPrimaryKey(id);
                ds.LoadObject(_book);
                return _book;
            }
            catch
            {

            }
            return null;
        }

        // POST api/<booksController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] book _book)
        {
            _book.tags =null;
            var _user = new user();
            _user.books.Add(_book);
            // var _report = new report();
            // var _meeting = new meeting();
            // var _speaker = new speaker();

            // _meeting.dateMeeting = DateTime.Now;
            // _book.reports.Add(_report);
            // _meeting.reports.Add(_report);
            //_speaker.reports.Add(_report);

            var p = new DataObject[] { _book, _user };

            ds.UpdateObjects(ref p);//Добавить Объект
        }

        // PUT api/<booksController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(Guid id, [FromBody] book _book)
        {
            try
            {
               _book.tags = null;
               book Book = new book();
               Book.SetExistObjectPrimaryKey(id);
               ds.LoadObject(Book);
               Book.SetProperties(_book);
               Book.SetStatus(ObjectStatus.Altered);
               ds.UpdateObject( Book);//Добавить Объект
            }
            catch
            {

            }
        }

        // DELETE api/<booksController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(Guid id)
        {
            try
            {
                book Book = new book();
                Book.SetExistObjectPrimaryKey(id);
                ds.LoadObject(Book);

                Book.SetStatus(ObjectStatus.Deleted);
                ds.UpdateObject(Book);
            }
            catch
            {

            }
        }
    }
}
