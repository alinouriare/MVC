using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Infrastructures;

namespace StateManagement.Controllers
{
    public class TestController : Controller
    {
        private readonly ICacheProvider cache;

        public TestController(ICacheProvider cache)
        {
            this.cache = cache;
        }
        public IActionResult Index()
        {
            cache.Set("Name", "ali");
            ViewBag.Name = cache.Get("Name");
            return View();
        }
    }
}