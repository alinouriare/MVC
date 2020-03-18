using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace StateManagement.Controllers
{
    public class MemoryCacheController : Controller
    {
        private readonly IMemoryCache memoryCache;

        public MemoryCacheController(IMemoryCache memoryCache )
        {
            this.memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            SetCache("FirstName", "Ali");
            SetCache("LastName", "AliNouri");
            ViewBag.FirstName = GetCache("FirstName");
            ViewBag.LastName = GetCache("LastName");
            return View();
        }


        private void SetCache(string key ,string value)
        {
            //var options = new MemoryCacheEntryOptions();
          
            memoryCache.Set(key, value);
        }

        private string GetCache(string key)
        {
            return memoryCache.Get(key).ToString();
        }
    }
}