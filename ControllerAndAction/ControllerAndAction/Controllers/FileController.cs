using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAndAction.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {

            // return File("/twitter-bootstrap/css/bootstrap.css","text/css","testfileresultdownload.css");

            var by = System.IO.File.ReadAllBytes(@"C:\Users\AliNouri\Desktop\Core\MVC\ControllerAndAction\ControllerAndAction\wwwroot\twitter-bootstrap\css\bootstrap.css");
            return File(by,"text/css");
            //return View();
        }
    }
}