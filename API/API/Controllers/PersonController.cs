using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class Error
    {
        public string Key { get; set; }

        public string Desc { get; set; }
    }


    public class ApiResponse<TData>
    {
        public ApiResponse(List<TData> datas,string mes)
        {
            Datas = datas;
            Message = mes;
        }
        public TData Data { get; set; }

        public List<TData> Datas { get; set; }
        public string Status { get; set; }

        public string Message { get; set; }

        public List<Error> Errors { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
     
        private readonly IPersonRepository personRep;

        public PersonController(IPersonRepository person)
        {
      
            this.personRep = person;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result= personRep.GetPeople();
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            var result= personRep.Get(id);
            if ( result==null)
                return NotFound(new ApiResponse<Person>(personRep.GetPeople(),"ffff"));
            return Ok(result); 
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            personRep.Add(person);
            return Created("api/Person"+person.Id,person);
        }

        //[HttpPost]
        //[RoutePrefix("api/v1/BankBranchs")]
        //[Route("GetBankBranchs")]


        //public void test(Person person)
        //{
        //    personRep.Add(person);
        //}

        //[HttpPut("{id}")]
        //public void Put(int id,[FromBody]Person person)
        //{

        //}


        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}