using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StateManagement.Infrastructures;

namespace StateManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            bool useDistributed = true;


            if (useDistributed)
            {
                services.AddTransient<ICacheProvider, DistributedCache>();
            }
            else
            {
                services.AddTransient<ICacheProvider, InMemory>();

            }

            //dotnet sql-cache create "Data Source=.\AliNouri;Initial Catalog=DistCache;Integrated Security=True;" dbo TestCache
            services.AddDistributedSqlServerCache(c =>
            {

                c.ConnectionString = "Data Source=.;Initial Catalog=DistCache;Integrated Security=True;";
                c.TableName = "TestCache";
                c.SchemaName = "dbo";
            });
            //services.AddMemoryCache();
            //services.AddSession(c=> { 


            //});

            services.AddSession();
            services.AddMvc();

            //defualt tempdata in cookies in version now change code under
            //services.AddMvc().AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }
}
