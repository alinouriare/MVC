using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DICtest.Infrastructure;
using DICtest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DICtest.Controllers
{
    public class HomeController : Controller
    {

        //public IRepository Repository { get; set; }// = new MemoryRepository();

        private readonly IScopeService scopeService;
        private readonly ITransientService transientService;
        private readonly ISingletoneService singletoneService;

        public HomeController(/*IRepository repository,*/ IScopeService scopeService, ITransientService transientService
       , ISingletoneService singletoneService)
        {
            this.scopeService = scopeService;
            this.transientService = transientService;
            this.singletoneService = singletoneService;
            //Repository = repository;
        }

        //action repository
    
        public IActionResult Index([FromServices]IRepository repository)
        {
            var servicelocator = HttpContext.RequestServices.GetService(typeof(IRepository));
 
            return View(repository.Products);
        }
    }
}