using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Models;

namespace User.Infrastructures
{
    public class CheckFilter : ActionFilterAttribute
    {
        //public override void OnResultExecuting(ResultExecutingContext context)
        //{




        //}


     
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var Ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
            if (Ip.Contains("::1"))
            {
                ////Test test = new Test { Name = "ali" };

                ////var result = context.Result as ViewResult;
                ////var ww = result.ViewName;
                ////result.ViewName = "Error";
                ////result.ViewData.Add("a", test);
             
                context.Result= new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "Home" },
                                          { "action", "Error" }

                                         });
            }
        }
    }
}
