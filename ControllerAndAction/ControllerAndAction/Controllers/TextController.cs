using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAndAction.Controllers
{
    public class TextController : Controller
    {
        public IActionResult Json()
        {
            return Json(new { firstname="ali",lastname="nouri"});
        }

        public IActionResult text()
        {
            return Content("Content ali","text/text");
        }

        public IActionResult css()
        {
            return Content(".header{ background-color:red}", "text/css");
        }
    }
}