using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepository personRepository;

        public HomeController(IPersonRepository  personRepository)
        {
            this.personRepository = personRepository;
        }
        public IActionResult Index()
        {
            return View(personRepository.GetPeople());
        }

        public IActionResult AddPerson(Person person)
        {
            personRepository.Add(person);
            return RedirectToAction("Index");
        }
        public IActionResult TestApi()
        {
            return View();
        }



        [HttpPost]
       
        public JsonResult ttt(Person person)
        {
            personRepository.Add(person);
            return Json(new { status = false });

        }
    }
}