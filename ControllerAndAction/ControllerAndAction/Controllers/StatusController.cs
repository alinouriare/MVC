using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAndAction.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            // return Ok();
            //201
            // return Created("url", new { });
            //400
            // return BadRequest();

            // return NoContent();

            //  return Unauthorized();

            return StatusCode(404, new { });


        }
    }
}