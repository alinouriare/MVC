using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Models;

namespace User.Controllers
{
    public class AccountController : Controller
    {
         private  UserManager<AppUser> userManager;
        private  SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    //var tryCount = user.AccessFailedCount;
                    //bool lockUser = tryCount >= 5;
                    Microsoft.AspNetCore.Identity.SignInResult result =
                    await signInManager.PasswordSignInAsync(
                    user, details.Password, false, lockoutOnFailure: false);

                    //var result = await signInManager.PasswordSignInAsync(user, details.Password, false,true);
                    ////await signInManager.SignInAsync(user,false);

                    if (result.Succeeded)
                    {
                        return LocalRedirect(returnUrl ?? "/");
                        //return RedirectToAction("Index", "Admin");
                        ////return Redirect("http://localhost:51856/Admin/Index");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Email),
                "Invalid user or password");
            }
            return View(details);
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}