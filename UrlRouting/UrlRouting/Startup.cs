using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using UrlRouting.Infrastructures;

namespace UrlRouting
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("weekday", typeof(WeekdayConstraint));
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvc(route =>
            //{

            //    //route.MapRoute("default", "/{controller=Home}/{action=index}");
            //    route.MapRoute("default", "/{controller}/{action}",defaults:new{ action="Index",controller="home"});
            //});


            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "TestSegment/{controller=Home}/{action=index}");
            //});
            //static segment
            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "/p{controller=Home}/{action=index}");
            //});

            //app.UseMvc(route =>
            //{
            //    route.MapRoute("old", "/news", defaults: new { action = "Index", controller = "Content" });


            //    route.MapRoute("default", "/{controller=Home}/{action=index}");
            //});


            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "/{controller=Home}/{action=index}/{id=9}");
            //});

            //optional id ?///http://localhost:52444/?id=3333333
            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "/{controller=Home}/{action=index}/{id?}");
            ////});
            ////http://localhost:52444/home/index/1/alalla/lallaal
            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "/{controller=Home}/{action=index}/{id?}/{*catchall}");
            //});
            //contraint
            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "/{controller=Home}/{action=index}/{id:int}");
            //});

            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "/{controller=Home}/{action=index}/{id:alpha}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default",
            //        "/{controller=home}/{action=index}/{id}",
            //        defaults: new { },
            //        constraints: new { id = new AlphaRouteConstraint() });
            //});
            //or maxlength(55)
            //int reng(1,100) and regex
            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "/{controller=Home}/{action=index}/{id:length(3)}");
            //});

            //custome constraint
            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "/{controller=Home}/{action=index}/{id=sat}"
            //        , defaults: new { },
            //   constraints: new { id = new WeekdayConstraint() });
            //});
            //app.UseMvc(route =>
            //{

            //    route.MapRoute("default", "/{controller=Home}/{action=index}/{id:weekday=sat}");


            //});

            app.UseMvc(route =>
            {
                // route.Routes.Add(new LegacyRoute("/articles/Windows_3.1_Overview.html","/old/.NET_1.0_Class_Library"));
                // route.Routes.Add(new LegacyRoute(app.ApplicationServices, "/articles/Windows_3.1_Overview.html", "/old/.NET_1.0_Class_Library"));
                route.MapRoute(
               name: "areas",
               template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
             );
                route.MapRoute("default", "/{controller=Home}/{action=index}/{id?}");


            });

        }
    }
}
