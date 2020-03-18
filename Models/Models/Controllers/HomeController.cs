using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace Models.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        //http://localhost:54465/home/index/2/?id=1 defualt route
        public ViewResult Index([FromQuery]int? id)
        {

            return View(repository.GetPerson(id ?? 0 ));
        }


        public IActionResult Create()
        {
            return View(new Person());
        }
        [HttpPost]
        public IActionResult Create( Person person)
        {
            return View();
        }

        public IActionResult DisplaySummary([Bind("City", "Country", Prefix = "HomeAddress")] AddressSummary addressSummary)
        {

            return Json(addressSummary);
        }
      

        public IActionResult Names()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Names(List<string> fullName/*,List<int> Checked*/,int[] Checked)
        {
            return Ok(fullName);
        }

        public IActionResult People()
        {

            return View(new PersonSummary());
        }

        [HttpPost]
        public IActionResult People(List<PersonSummary>  personSummaries)
        {
            return Ok(personSummaries);
        }

        public IActionResult HeaderData([FromHeader]string accept)
        {
            return Json(accept);
        }
    }
}