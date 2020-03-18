using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Infrastructures
{

    public class ShortCircuitMiddleware
    {

        private  RequestDelegate nextDelegate;

        public ShortCircuitMiddleware(RequestDelegate next) => nextDelegate = next;

        public async Task Invoke(HttpContext httpContext)
        {
            //bool isEdge = bool.Parse(httpContext.Items["EdgeBrowser"].ToString());

            var a = httpContext.Request.Headers["User-Agent"].ToString();

            if (httpContext.Request.Headers["User-Agent"].Any(p=>p.ToLower().Contains("edge")))
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
       
    }
}
