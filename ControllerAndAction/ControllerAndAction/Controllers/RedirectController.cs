using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAndAction.Controllers
{
    public class RedirectController : Controller
    {
        public IActionResult Index()
        {
            //301 tempolar 302 permanet
            //any url
            // return Redirect("Url");

            //return RedirectToRoute(new {controller="",action="" });

            //return RedirectToAction("Index", "Home");
            //address local phishing
            //            return LocalRedirect("");

            // return RedirectPermanent("");
            return View();
        }
    }
}