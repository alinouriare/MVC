using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //[MyHttpsFilter]
    [TestOutput("COntroller")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Request.IsHttps)
            {
                return View();
            }
            return StatusCode(404);
        }
        //[MyHttpsFilter]
        //[MyActionFilter]
        //[MyResultFilter]
        //[TypeFilter(typeof(MyHybridFilter))]فقط وابستگی از DI core
        //[ServiceFilter(typeof(SingletoneAttribute))]طول عمر
        [TestOutput("Action 1")]
        [TestOutput("Action 2",Order =-1)]
        public IActionResult NewsList()
        {
            Person person = new Person { Id = 1, Name = "ali" };
            return View(person);
        }

        public IActionResult Test()
        {
            int a;
            a = 25;
            if (a is int)
            {
                return Content("dd");
            }
            return Content("ddppp");
        }

    }
}