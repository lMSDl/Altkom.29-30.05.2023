using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppOld
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            var a = app.ApplicationServices.GetService<ILogger<Startup>>();

            if (env.EnvironmentName == "MojKomputer")
            {
                app.UseDeveloperExceptionPage();
            }


            app.Use(async (context, next) =>
            {
                await next();
            });

            app.UseRouting();


            app.Use(async (context, next) =>
            {
                await next();
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/demo/hello", async context =>
                {
                    await context.Response.WriteAsync("Hello demo!");
                });
                endpoints.MapGet("/", async context =>
                {
                    throw new Exception();
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
