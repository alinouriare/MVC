using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewAndHelper.Models;

namespace ViewAndHelper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new BlogHomePage
            {
                Ads=new List<Ads> { new Ads { 
                
                Id=1,Description="Description",Titr="Titr 1"
                } ,new Ads {

                Id=2,Description="Description",Titr="Titr 3"
                }},

                Comments = new List<Comment> { new Comment { Id = 1,
                        Description ="Bad Post" } }

            };
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }
    }
}