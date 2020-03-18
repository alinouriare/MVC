using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UrlRouting.Controllers
{
    public class ReuseController : Controller
    {
        public IActionResult Index(int id)
        {
            return View(id);
        }
    }
}