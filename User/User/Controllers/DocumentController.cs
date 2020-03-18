using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Models;

namespace User.Controllers
{
    public class DocumentController : Controller
    {
        private IAuthorizationService authService;
        public DocumentController(IAuthorizationService auth)
        {
            authService = auth;
        }

        private ProtectedDocument[] docs = new ProtectedDocument[]
        {
             new ProtectedDocument { Title = "ASP.NET Core", Author = "ali",Editor = "ali"},
            new ProtectedDocument { Title = "Project Plan", Author = "ali",Editor = "mehdi"},
            new ProtectedDocument { Title = "MongoDB", Author = "ali",Editor = "mehdi"}
        };
        public ViewResult Index() => View(docs);


        public async Task<IActionResult> Edit(string title)
        {
            ProtectedDocument doc = docs.FirstOrDefault(d => d.Title == title);
            AuthorizationResult authorized = await authService.AuthorizeAsync(User, doc, "AuthorsAndEditors");


            
            if (authorized.Succeeded)
            {
                return View("Index", doc);

            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
}