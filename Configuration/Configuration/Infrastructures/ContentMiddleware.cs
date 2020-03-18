using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Infrastructures
{
    public class ContentMiddleware
    {
        private readonly UptimeService uptimeService;

        private RequestDelegate nextDelegate;

        public ContentMiddleware(RequestDelegate next, UptimeService uptimeService)
        {
            nextDelegate = next;
            this.uptimeService = uptimeService;
        }
           

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower()=="/middleware")
            {
                await httpContext.Response.WriteAsync($"This is from the context middleware UP{uptimeService.GetUpTime}",Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
       
    }
}
