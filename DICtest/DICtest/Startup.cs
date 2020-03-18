using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DICtest.Infrastructure;
using DICtest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DICtest
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITransientService, TransientService>();
            services.AddSingleton<ISingletoneService, SingletoneService>();
            services.AddScoped<IScopeService, ScopeService>();


            services.AddScoped<IComplexClass>(provider => {
                return new ComplexCalss("conctionstring");
            });
           


            services.AddScoped<ComplexCalssSQL>();
            services.AddScoped<ComplexCalssORACLE>();


            services.AddScoped<IComplexClass2>(provider => {

                bool needsql = true;
                return needsql ? (IComplexClass2)provider.GetService<ComplexCalssSQL>() :
                provider.GetService<ComplexCalssORACLE>();
            });
            services.AddMvc();
            services.AddTransient<IRepository, MemoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
