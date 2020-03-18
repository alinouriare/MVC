using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace ControllerAndAction.Controllers
{
    public class PocoInheritedController: BaseController
    {

        public string Index() => "Hello From Poco Controller";

        [NonAction]
        public string NotAction() => "Hello From NotAction";



        public ViewResult MyActionResult()
        {
            return View("Result", "Hell MyActionResult inherit base controller");
        }



        public IActionResult HeaderData()
        {

            //ControllerContext controllerContext = new ControllerContext();

            var dictionary = ControllerContext.HttpContext.Request.Headers.ToDictionary(c => c.Key, c => c.Value.First());

            return View("DictionaryResult", dictionary);

        }
    }
}
