using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using SelahSeries.Data;
using SelahSeries.Core;
using Microsoft.Net.Http.Headers;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace SelahSeries
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<SelahSeriesDataContext>(c =>
                 c.UseSqlServer(Configuration.GetConnectionString("SelahSeriesDB")));
            services.AddAutoMapper(typeof(Startup));
            services.AddCustomServices();

            services.Configure<CookieTempDataProviderOptions>(options => {
                options.Cookie.IsEssential = true;
            });
        

            services.AddMvc(options => options.Filters.Add(new AuthorizeFilter())).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "Signin";
                    options.LoginPath = "/Home/Login";
                    options.LogoutPath = "/Home";
                }
              )
              .AddGoogle("Google", options =>
                {
            
                  options.ClientId = Configuration["Authentication:Google:ClientId"];
                  options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];

                    options.Events = new OAuthEvents
                    {
                        OnCreatingTicket = context =>
                        {
                            string domain = context.User.Value<string>("email");
                            string[] allowedEmails = Configuration["Authentication:Google:LoginEmail"].Split(';');
                            if (!allowedEmails.Any(x => x.Equals(domain, StringComparison.OrdinalIgnoreCase)) )
                                throw new Exception($"You must sign in with a {Configuration["Authentication:Google:LoginEmail"]} email address");
                            return Task.CompletedTask;
                        }
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.Use(async (HttpContext, next) =>
            //{
            //    HttpContext.Response.Headers[HeaderNames.CacheControl] = "no-cache";
            //    await next();
            //});
            app.UseStaticFiles();
     
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
