using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Infrastructures;
using User.Models;

namespace User
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)

        {
            //services.AddSession();

            //services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();
            //services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator2>();
           

            services.AddDbContext<ApplicationDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>(c =>
            {

                c.Password.RequireDigit = false;
                c.Password.RequiredLength = 3;
                c.Password.RequiredUniqueChars = 2;
                c.Password.RequireLowercase = false;
                c.Password.RequireNonAlphanumeric = false;
                c.Password.RequireUppercase = false;
                //c.User.AllowedUserNameCharacters = "asd";
                //c.User.RequireUniqueEmail = false;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();



            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "auth_cookie";
            //    options.AccessDeniedPath = "/Account/Login";
            //    options.LoginPath = "/Account/Login";
            //    options.LogoutPath = "/Account/LogOff";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;

            //});


            services.AddSingleton<IClaimsTransformation, LocationClaimsProvider>();
            services.AddTransient<IAuthorizationHandler, BlockUsersHandler>();

            services.AddTransient<IAuthorizationHandler, DocumentAuthorizationHandler>();


            services.AddAuthorization(c =>
            {
                c.AddPolicy("Country", policy => {

                    policy.RequireClaim(ClaimTypes.Country);
                });
                c.AddPolicy("Allstate", policy =>
                {
                    //policy.RequireRole("Users");
                    policy.RequireClaim(ClaimTypes.StateOrProvince);
                });
                c.AddPolicy("Tehran", policy =>
                {
                    //policy.RequireRole("Users");
                    policy.RequireClaim(ClaimTypes.StateOrProvince, "Tehran");
                });
                c.AddPolicy("DC", policy =>
                {
                    //policy.RequireRole("Users");
                    policy.RequireClaim(ClaimTypes.StateOrProvince,"DC");
                });

                c.AddPolicy("NotMahdi", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new BlockUsersRequirement("Mehdi"));
                });

                c.AddPolicy("AuthorsAndEditors", policy => {
                    policy.AddRequirements(new DocumentAuthorizationRequirement { 
                    
                    AllowAuthors=true,
                    AllowEditors=true,
                    });
                
                });
            });

            //services.AddAuthorization();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseSession();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
