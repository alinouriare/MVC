using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StateManagement.Controllers
{
    public class ContextItemsController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Items["Check"] = new {FirstName="Ali",LastName="Nouri" };
            return View();
        }
    }
}