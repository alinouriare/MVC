using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index()
        {
            var result = new Result
            {
                Controller = nameof(AdminController),
                Action = nameof(Index)
            };

            return View("Result", result);
        }


        public ViewResult List()
        {
            var result = new Result
            {
                Controller = nameof(AdminController),
                Action = nameof(List)
            };

            return View("Result", result);
        }
    }
}