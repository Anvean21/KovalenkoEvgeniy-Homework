using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePractice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AspCoreContext>(options => options.UseSqlServer(connection));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options => 
                {
                  options.LoginPath = new PathString("/signin");
              });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            else { app.UseExceptionHandler("/Home/Error"); app.UseHsts(); }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                logger.LogInformation("LogInformation {0}", context.Request.Path);
                context.Response.Headers.Add("X-Checked-By", $"{Configuration["lastName"]}");
                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                var stringQuery = context.Request.Query["r"].ToString();
                context.Response.Redirect(stringQuery);
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "/", "/", new { controller = "User", action = "Index" });

                endpoints.MapGet("/hello", async context =>
                {   
                    await context.Response.WriteAsync($"Hello, {Configuration["name"]}");
                });
                endpoints.MapGet("/hello.json", async context =>
                {
                    await context.Response.WriteAsync($"Hello, {Configuration["name"]}." + "{" + $"data: {Configuration["phrase"]}" + "}");
                });
            });
        }
    }
}
