using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class imagesController : ControllerBase
    {
        IImage dataContext;
        public imagesController(IImage dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET: api/<imagesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<imagesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var img = dataContext.getId(id);

            var base64EncodedBytes = System.Convert.FromBase64String(img.img);
            //string base64 = Convert.ToBase64String(File.ReadAllBytes("image.jpg"));
            //Byte[] b = System.IO.File.ReadAllBytes(@"E:\\Test.jpg");   // You can use your own method over here.         
            return File(base64EncodedBytes, "image/jpeg");
        }

        // POST api/<imagesController>
        [HttpPost]
        public IActionResult Post([FromBody] image _image)
        {
            dataContext.add(_image);
            return Ok(new { __PrimaryKey = new { guid = _image.__PrimaryKey } });
        }

        // PUT api/<imagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<imagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
