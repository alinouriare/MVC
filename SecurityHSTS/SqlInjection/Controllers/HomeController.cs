using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqlInjection.Models;

namespace SqlInjection.Controllers
{
    public class HomeController : Controller
    {
        public object Index(string userName,string password)
        {
            userName = "ali' or 1=1 --";
            string sql = "select * from Users where userName='" + userName + " 'and password='" + password + "'";
            SqlConnection connection = new SqlConnection("Server=.;Database=Inject;Trusted_Connection=True;MultipleActiveResultSets=true");
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var id = command.ExecuteScalar();
            var a = command.ExecuteNonQuery();
            var d = command.ExecuteReader();
           
            //var t = command.BeginExecuteXmlReader();
            if (id !=null)
            {
                return id;
            }
            return "NotFound";
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
