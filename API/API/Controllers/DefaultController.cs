using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET: api/Default
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        [Produces(contentType: "application/json")]
        public object Get(int id)
        {
            return new Person { Id=id,FirstName="ALI",LastName="NOURI"};
        }

        // POST: api/Default
        [HttpPost]
        public int Post()
        {
          return  1;
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
