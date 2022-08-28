using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using BookLibrary.Models;
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
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        IBook dataContext;
        public booksController(IBook dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET: api/<booksController>
        [HttpGet]
        public IEnumerable<BookModel> Get()
        {
            var temp = dataContext.getAll();
            return dataContext.getAll().Select(u=>new BookModel(u));
        }

        // GET api/<booksController>/5
        [HttpGet("{id}")]
        public BookModel Get(Guid id)
        {
            return new BookModel(dataContext.getId(id));
        }

        // POST api/<booksController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] BookModel model)
        {
            var _book = new book();
            _book = model;
            var id = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
            dataContext.add(_book, Guid.Parse(id));
            return Ok(new { __PrimaryKey = new { guid = _book.__PrimaryKey } });
        }

        // Patch 
        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult Patch(Guid id, [FromBody] BookModel _book)
        {
            dataContext.update(id, _book);
            return Ok(new { __PrimaryKey = new { guid = id } });
        }

        // DELETE api/<booksController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
           dataContext.delete(id);
            return Ok(new { __PrimaryKey = new { guid = id } });
        }
    }
}
