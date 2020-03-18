using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vlidations.Models;

namespace Vlidations.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ViewResult MakeBooking(Appointment appt)
        {

            //if (string.IsNullOrEmpty(appt.ClientName))
            //{
            //    ModelState.AddModelError(nameof( appt.ClientName), "Plese Enter Your Name");
            //}
            //else if (appt.ClientName.Length < 3)
            //{
            //    ModelState.AddModelError(nameof(appt.ClientName), "More Then 3 Chatchter!");
            //}

            //if (ModelState.GetValidationState("Date")==Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid
            //    && DateTime.Now.Date  > appt.Date)
            //{
            //    ModelState.AddModelError(nameof(appt.Date), "Please enter a date in the future");
            //}

           // if (!appt.TermsAccepted)
           // {
           //     ModelState.AddModelError(nameof(appt.TermsAccepted) , "You must accept the terms");
           // }
           // if (!string.IsNullOrEmpty(appt.ClientName) && ModelState.GetValidationState("Date")
           //== ModelValidationState.Valid && (appt.ClientName == "Shamekhi" && appt.Date.Date == DateTime.Now.Date))
           // {
           //     ModelState.AddModelError("", "You can not select today");
           // }
            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View("Index");
            }
          
        }

        public JsonResult ValidateUserName(string userName)
        {
            return Json(true);
        }
    }
}