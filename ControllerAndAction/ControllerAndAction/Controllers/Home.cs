using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControllerAndAction.Infrastructures;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllerAndAction.Controllers
{
    public class Home : Controller
    {
        // GET: /<controller>/
        public string Index() => "Hello From Home Controller";



        public IActionResult HeaderData()
        {
            var headers = Request.Headers.ToDictionary(c => c.Key, c => c.Value.First());

            return View("DictionaryResult", headers);
        }


        public ViewResult SimpleForm() => View("SimpleForm");

        public ViewResult ReciveForm01()
        {
            var name = Request.Form["name"];
            var city = Request.Form["city"];
            return View("Result", $"{name}live in {city}");
        }

        public ViewResult ReciveForm02(string name,string city)
        {
            //var name = Request.Form["name"];
            //var city = Request.Form["city"];
            return View("Result", $"{name}live in {city}");
        }

        public void ReciveForm03(string name, string city)
        {
            Response.StatusCode = 200;
            Response.ContentType = "text/html";
            byte[] content = Encoding.ASCII.GetBytes($"<html><body>{name} live in {city}</body></html>");
            Response.Body.WriteAsync(content,0,content.Length);
       
     
        }

        //public IActionResult ReciveForm04(string name, string city)
        //{
        //    return new MyHtmlActionResult
        //    {
        //        Content= $"{name} live in {city}"
        //    };


        //}


        public MyJsonResult ReciveForm(string name, string city)
        {
            var obj = new { name, city };
            return new MyJsonResult
            {
                Content = obj
            };


        }
    }
}
