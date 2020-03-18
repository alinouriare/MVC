using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Models;

namespace User.ViewComponents
{
    public class RoleViewComponent: ViewComponent
    {
        private RoleManager<IdentityRole>  roleManager;

        public RoleViewComponent(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IViewComponentResult Invoke()
        {
            var Mole= roleManager.Roles.ToList();
            return View(Mole);
        }
    }
}
