using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    public class ContentController : Controller
    {
       
            public ViewResult Index()
            {
                return View("Result",
                    new Result
                    {
                        Controller = nameof(ContentController),
                        Action = nameof(Index)
                    });
            }
       
        public class LegacyController : Controller
        {
            public ViewResult GetLegacyUrl()
            {
                return View("Result",
                    new Result
                    {
                        Controller = nameof(LegacyController),
                        Action = nameof(GetLegacyUrl)
                    });
            }
        }
    }
}