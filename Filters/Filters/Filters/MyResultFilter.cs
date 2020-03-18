using Filters.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Filters
{
    public class MyResultFilter : ResultFilterAttribute
    {
        private Stopwatch stopwatch;
        private long startTime, endTime;

        public MyResultFilter()
        {
            stopwatch = Stopwatch.StartNew();
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            
            startTime = stopwatch.ElapsedMilliseconds;
            var result = context.Result as ViewResult;
            // as ViewResult; 

            var viewName = result.ViewName;
            //var model = result.Model;
            var model = result.Model as Person;
            model.Name = "Reza";
        }


        public override void OnResultExecuted(ResultExecutedContext context)
        {
            if (context.Result is ViewResult)
            {
                var result = context.Result as ViewResult;
                // as ViewResult; 

                var viewName=  result.ViewName;
                //var model = result.Model;
             
            }

            stopwatch.Stop();
            endTime = stopwatch.ElapsedMilliseconds;
            string response = $"<div>request start: {startTime} ms and ent: {endTime} ms</div>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(response);
            context.HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
           
        }
    }
}
