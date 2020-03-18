using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace User.Controllers
{
    public class RoleManagerController : Controller
    {

        private RoleManager<IdentityRole> roleManager;

        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var role =  roleManager.Roles.ToList();
            return View(role);
        }

        public IActionResult Create( )
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name)
        {
            if (!roleManager.RoleExistsAsync(name).Result)
            {
                var result = roleManager.CreateAsync(new IdentityRole(name)).Result;
            }
            

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            var role = roleManager.FindByIdAsync(id).Result;

            if (role !=null)
            {
                var result = roleManager.DeleteAsync(role).Result;
            }

            return RedirectToAction("Index");

        }
    }
}