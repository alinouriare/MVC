using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerAndAction.Controllers
{


    public class PocoController
    {

        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }



        //public HttpRequest Request => ControllerContext.HttpContext.Request;

        //public HttpResponse Response => ControllerContext.HttpContext.Response;

        //public HttpContext HttpContext => ControllerContext.HttpContext;

        //public ClaimsPrincipal User => ControllerContext.HttpContext.User;




        public string Index() => "Hello From Poco Controller";

        [NonAction]
        public string NotAction() => "Hello From NotAction";



        public ViewResult MyActionResult()
        {
            return new ViewResult {

                ViewName = "Result",
                
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {

                    Model = "Hello from MyActionResult",
                    
            }
            };
        }



        public IActionResult HeaderData()
        {

            //ControllerContext controllerContext = new ControllerContext();

            var dictionary =ControllerContext.HttpContext.Request.Headers.ToDictionary(c => c.Key, c => c.Value.First());



                 return new ViewResult
                 {

                     ViewName = "DictionaryResult",

                     ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                     {

                         Model = dictionary

                     }
                 };
        }
    }
}
