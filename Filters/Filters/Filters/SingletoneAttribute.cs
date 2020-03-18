using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Filters
{
    public class SingletoneAttribute : ActionFilterAttribute
    {
        private int counter = 0;
        public SingletoneAttribute()
        {
            counter = 0;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            counter++;
        }


        public override void OnResultExecuted(ResultExecutedContext context)
        {
            string result = $"<h1>{counter}</h1>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(result);
            context.HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
        }
    }
}
