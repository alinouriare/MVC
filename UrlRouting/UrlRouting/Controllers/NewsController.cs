using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    public class NewsController : Controller
    {
        public ViewResult Default(string id)
        {
            var result = new Result
            {
                Controller = nameof(NewsController),
                Action = nameof(Default)
            };

            result.Data["id"] = id;
            return View("Result", result);
        }
    }
}