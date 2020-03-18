using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using User.Infrastructures;
using User.Models;

namespace User.Controllers
{
    public class HomeController : Controller
    {
        //    [CheckFilter]
        public IActionResult Index()
        {
            //var model = new Test { Name = "oh" };
            return View();
        }

        public IActionResult Error()
        {
            Test model = new Test { Name = "oh" };

            //Writeto("a",model);
            //ViewBag.s = GetTo("a");
            return View(model);
        }


        private void Writeto(string key ,Test val)
        {
            HttpContext.Session.SetString(key, JsonConvert.SerializeObject(val));
        }

        private string GetTo(string key)
        {
            return JsonConvert.DeserializeObject(HttpContext.Session.GetString(key)).ToString();
        }
    }
}