using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlRouting.Models;

namespace UrlRouting.Areas.AAA.Controllers
{
    [Area("AAA")]
    public class HomeController : Controller
    {
        public ViewResult Index(/*string id*/)
        {
            //var rotedata = RouteData.Values["id"];
            var result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index),

            };
            //result.Data["id"] =  RouteData.Values["id"];
            result.Data["Area"] = "AAA";
            //result.Data["id"] = id;
            //result.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", result);
        }
    }
}