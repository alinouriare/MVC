using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StateManagement.Controllers
{
    public class TempDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private void Write(string key,string value)
        {
            TempData[key] = value;
        }

        private string Get(string key)
        {
            return TempData[key].ToString();
        }

        private string Peek(string key)
        {
          return  TempData.Peek(key).ToString();
        }
    }
}