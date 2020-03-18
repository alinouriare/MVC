using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Models;

namespace User.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<AppUser> userManager;
        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;
        public AdminController(UserManager<AppUser> usrMgr,
                                      IUserValidator<AppUser> userValid,
                                      IPasswordValidator<AppUser> passValid,
                                      IPasswordHasher<AppUser> passwordHash,
                                      RoleManager<IdentityRole>  roleMgr)
        {
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
            roleManager = roleMgr;
        }
        public IActionResult Index()
        {

            var user = userManager.Users.ToList();
            return View(user);
        }


        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName=model.Name,
                    Email=model.Email,
                    FirstName=model.FirstName,
                    LastName=model.LastName
                    
                };

                IdentityResult result = userManager.CreateAsync(user, model.Password).Result;

                
                if (result.Succeeded)
                {
                    userManager.AddClaimAsync(user, new Claim(ClaimTypes.Country, "Iran"));

                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);

        }


        public async   Task<IActionResult> Delete(string id)
        {
            AppUser user =await userManager.FindByIdAsync(id);

            if ( user !=null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }

            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index",userManager.Users);
        }



        public async Task<IActionResult> Edit(string id)
        {
            AppUser user =await userManager.FindByIdAsync(id);



            if (user !=null)
            {

                return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Edit(AppUser editUser)
        {
            AppUser user = await userManager.FindByIdAsync(editUser.Id);
            
            if (user !=null)
            {
                user.Email = editUser.Email;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);

                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(editUser.PasswordHash))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager,user,editUser.PasswordHash);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, editUser.PasswordHash);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }

                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && editUser.PasswordHash != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }

            return View(user);
        }


        public IActionResult AddUsertToRole()
        {
            //AddRole vm = new AddRole();
            var Users1 = userManager.Users.ToList();
            var Role1 = roleManager.Roles.ToList();
            //vm.use = Users1;
            ViewBag.u = Users1;
            ViewBag.r = Role1;
            return View();
        }
        [HttpPost]
        public IActionResult AddUsertToRole(string iduser,string idrole)
        {
            var user = userManager.FindByIdAsync(iduser).Result;

            var role= roleManager.FindByIdAsync(idrole).Result;


            var result = userManager.AddToRoleAsync(user, role.Name).Result;

            

            return RedirectToAction("Index");
        }



        public IActionResult GetRole(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            var role = userManager.GetRolesAsync(user).Result;
            return Json(role);
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }

        }

     
    }
}