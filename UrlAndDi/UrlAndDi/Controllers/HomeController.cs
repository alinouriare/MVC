using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlAndDi.Models;

namespace UrlAndDi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index( [FromServices]IMyDependency myDependency)
        {
            //var a = RouteData.Values["Slug"].ToString();

            var text = myDependency.GetText();
            return View();
        }

        public IActionResult Privacy()
        {

       
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
