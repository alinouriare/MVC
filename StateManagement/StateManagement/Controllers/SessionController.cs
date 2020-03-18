using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace StateManagement.Controllers
{

    public class Person
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

    public static class SessionHelpers
    {

        public static T Get<T>(this HttpContext context ,string key)
        {
            return JsonConvert.DeserializeObject<T>(context.Session.GetString(key));

            
        }

        public static void Set<T>(this HttpContext context,string key,T inputValue)
        {
            context.Session.SetString(key, JsonConvert.SerializeObject(inputValue));
        }
    }
    public class SessionController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.SessionId = HttpContext.Session.Id;


            WriteToSession("My", new Person { FirstName = "Ali", LastName = "Nouri" });
            return View();
        }

        private void WriteToSessionMemo(string key, Person value)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream sr = new MemoryStream())
            {
                bf.Serialize(sr, value);
                var bytes = sr.ToArray();
                HttpContext.Session.Set(key, bytes);
            }
        }

        private void WriteToSession(string key, Person value)
        {
            
            HttpContext.Session.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value));
        }


        private void ReadFromSession(string key)
        {
           var result= HttpContext.Session.GetString(key);
        }

     
    }


  
}