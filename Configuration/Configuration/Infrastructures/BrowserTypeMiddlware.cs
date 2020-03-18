using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Infrastructures
{
    public class BrowserTypeMiddlware
    {

        private RequestDelegate nextDelegate;
        public BrowserTypeMiddlware(RequestDelegate next) => nextDelegate = next;

       
        public async Task Invoke(HttpContext httpContext)
        {

            ////bool isEdge = bool.Parse(httpContext.Items["EdgeBrowser"].ToString());
            //if (isEdge)
            //{
            //    httpContext.Response.StatusCode = 403;
            //}
            //else
            //{
            //   await nextDelegate.Invoke(httpContext);
            //}
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(v => v.ToLower().Contains
              ("edge"));
            await nextDelegate.Invoke(httpContext);
        }

    }
}
