using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(string id)
        {
            //var rotedata = RouteData.Values["id"];
            var result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index),

            };
            //result.Data["id"] =  RouteData.Values["id"];

            result.Data["id"] = id;
            //result.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", result);
        }
            [Route("/test")]
            public ViewResult Index2(string id)
            {
        
                // Url.Action("", "", new { });
                var result = new Result
                {
                    Controller = nameof(HomeController),
                    Action = nameof(Index2),
                };
                result.Data["id"] = id;// RouteData.Values["id"];
                                       //result.Data["catchall"] = RouteData.Values["catchall"];// RouteData.Values["id"];
                return View("Result", result);
            }
        }
}