using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L1_ServerOperation.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace L1_ServerOperation
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            appLifetime.ApplicationStarted.Register(FuncWhenStartApp);
            appLifetime.ApplicationStopped.Register(FuncWhenEndApp);

            app.UseRouting();

            app.UseMyMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!\n");
                });
            });
            
        }

        private void FuncWhenStartApp()
        {
            Console.WriteLine("在Configure註冊ApplicationStarted就可以在啟動App時跑這個Function");
        }

        private void FuncWhenEndApp()
        {
            Console.WriteLine("在Configure註冊ApplicationStopped就可以在關閉App時跑這個Function");
        }
    }
}
