using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configuration.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService uptimeService;
        private readonly IConfiguration configuration;
        private readonly ILogger<HomeController> logger;

        public HomeController(UptimeService uptimeService, IConfiguration configuration,ILogger<HomeController> logger)
        {
            this.uptimeService = uptimeService;
            this.configuration = configuration;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            logger.LogInformation("------------------------");
            logger.LogInformation($"Request Time{DateTime.Now}");


            Dictionary<string, string> valuePairs = new Dictionary<string, string>
            {

                ["Message"] = "Hello Word From Index Action",

                ["UpTime"] = $"Uptime Service:{uptimeService.GetUpTime} ms",
                ["ConfigValue"] =configuration["MyUserName"],
                ["PersonalData"] = configuration["PersonalData:Firstname"]
            };

            logger.LogInformation("------------------------");
            logger.LogInformation($"Request Time Finish{DateTime.Now}");
            return View(valuePairs);
        }
    }
}