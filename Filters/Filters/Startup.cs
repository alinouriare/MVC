﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Filters;
using Filters.Infrastructures;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Filters
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<SingletoneAttribute>();
            //services.AddMvc();
            services.AddScoped<ILogger, ConsoleLogger>();
            services.AddMvc().AddMvcOptions(c => {
                //c.Filters.AddService<SingletoneAttribute>();
                c.Filters.Add(new TestOutput("Global Filter"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
        }
    }
}
