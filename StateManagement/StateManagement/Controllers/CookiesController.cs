using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StateManagement.Controllers
{
    public class CookiesController : Controller
    {
        public IActionResult Index()
        {
            WriteToCookie("FirstName", "Ali");
            WriteToCookie("LastName", "Nouri");

            return View();
        }

        private void WriteToCookie(string key,string value)
        {
            //Response.Cookies.Delete();
            var options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
            //in domain
            //options.SameSite = SameSiteMode.Strict;
            //GET JUST
            //options.SameSite = SameSiteMode.Lax;
            Response.Cookies.Append(key, value, options);
        }


        public IActionResult ReadFromCookie()
        {
            ReadFromCookies();
            return View();
        }

        private void ReadFromCookies()
        {
            //Request.Cookies.Where(p=>p.Key==)
            ViewBag.FirstName = Request.Cookies["FirstName"];
            ViewBag.LastName = Request.Cookies["LastName"];
        }
    }
}