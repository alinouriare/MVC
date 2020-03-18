using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAndAction.Controllers
{
    public class HtmlController : Controller
    {
        public IActionResult Index2()
        {
            return View("Result", "This is index 2");
        }
        public IActionResult Index()
        {
        


            var name = TempData["name"];
            var city = TempData["city"];
            return View("Result", $"username {TempData["name"]} city: {TempData["city"]}");
        }
        public IActionResult SimpleForm() => View("SimpleForm");



        public IActionResult Index3() => View("Result","Complet");

        public IActionResult ReciveForm(string name, string city)
        {
            TempData["name"] = name;
            TempData["city"] = city;
            return RedirectToAction("Index2");
        }

        //public IActionResult ReciveForm(string name, string city)
        //{

        //    return RedirectToAction("Index3");
        //}
    }
}