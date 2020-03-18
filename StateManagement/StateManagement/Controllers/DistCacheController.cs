using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace StateManagement.Controllers
{
    public class DistCacheController : Controller
    {
        private readonly IDistributedCache cache;

        public DistCacheController(IDistributedCache cache)
        {
            this.cache = cache;
        }
        public IActionResult Index()
        {
            SetCache("FirstName", "Ali");
            SetCache("LastName", "AliNouri");
            ViewBag.FirstName = GetCache("FirstName");
            ViewBag.LastName = GetCache("LastName");
            return View();
        }


        private void SetCache(string key, string value)
        {
            //var options = new MemoryCacheEntryOptions();

            cache.SetString(key, value);
        }

        private string GetCache(string key)
        {
            return cache.GetString(key);
        }
    }
}