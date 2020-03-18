using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configuration.Infrastructures;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Configuration
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddSingleton<ShortCircuitMiddleware>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //IApplicationBuilder config middleware pipline and Route
        //IwebHostEnvironment mohit run app

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

          
             app.UseExceptionHandler("/error.html");
            


            //env.IsEnvironment("ali");
            //var aa = env.ContentRootPath.ToString();
            //var aa2 = env.ContentRootFileProvider.ToString();
            //var aa3 = env.ApplicationName.ToString();
            //var aa4 = env.WebRootPath.ToString();
            //var aa5 = env.WebRootFileProvider.ToString();
            //var aa6 = env.EnvironmentName.ToString();

            //app.UseMiddleware<ErrorMiddleware>();
            //app.UseMiddleware<BrowserTypeMiddlware>();
            //app.UseMiddleware<ShortCircuitMiddleware>();
            //app.UseMiddleware<ContentMiddleware>();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            //middlware if web not api
            app.UseStaticFiles();

         

            //app.UseMvcWithDefaultRoute();

        }

        //public void ConfigureDevelopmentServices(IServiceCollection services)
        //{
        //    services.AddSingleton<UptimeService>();
        //    services.AddSingleton<ShortCircuitMiddleware>();
        //    services.AddMvc();
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        ////IApplicationBuilder config middleware pipline and Route
        ////IwebHostEnvironment mohit run app

        //public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        //{

        //    //if (env.IsDevelopment())
        //    //{
        //    //    app.UseDeveloperExceptionPage();

        //    //}
        //    //else
        //    //{
        //    //    app.UseExceptionHandler("/error.html");
        //    //}
        //    app.UseDeveloperExceptionPage();


        //    //env.IsEnvironment("ali");
        //    //var aa = env.ContentRootPath.ToString();
        //    //var aa2 = env.ContentRootFileProvider.ToString();
        //    //var aa3 = env.ApplicationName.ToString();
        //    //var aa4 = env.WebRootPath.ToString();
        //    //var aa5 = env.WebRootFileProvider.ToString();
        //    //var aa6 = env.EnvironmentName.ToString();

        //    //app.UseMiddleware<ErrorMiddleware>();
        //    //app.UseMiddleware<BrowserTypeMiddlware>();
        //    app.UseMiddleware<ShortCircuitMiddleware>();
        //    //app.UseMiddleware<ContentMiddleware>();

        //    app.UseRouting();
        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Home}/{action=Index}/{id?}");
        //    });


        //    //middlware if web not api
        //    app.UseStaticFiles();



        //    //app.UseMvcWithDefaultRoute();

        //}
    }


    public class StartupDevelopment
    {


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddSingleton<ShortCircuitMiddleware>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //IApplicationBuilder config middleware pipline and Route
        //IwebHostEnvironment mohit run app

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();

            //}
            //else
            //{
            //    app.UseExceptionHandler("/error.html");
            //}
            app.UseDeveloperExceptionPage();


            //env.IsEnvironment("ali");
            //var aa = env.ContentRootPath.ToString();
            //var aa2 = env.ContentRootFileProvider.ToString();
            //var aa3 = env.ApplicationName.ToString();
            //var aa4 = env.WebRootPath.ToString();
            //var aa5 = env.WebRootFileProvider.ToString();
            //var aa6 = env.EnvironmentName.ToString();

            //app.UseMiddleware<ErrorMiddleware>();
            //app.UseMiddleware<BrowserTypeMiddlware>();
            app.UseMiddleware<ShortCircuitMiddleware>();
            //app.UseMiddleware<ContentMiddleware>();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            //middlware if web not api
            app.UseStaticFiles();

           

            //app.UseMvcWithDefaultRoute();

        }
    }
}
