using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L1_ServerOperation.Middlewares
{
    public static class CustomMiddlewareExtensions
    {
        public static void UseMyMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<MyMiddlewares>();
        }
    }

    public class MyMiddlewares
    {
        private readonly RequestDelegate _next;

        // "Scoped" SERVICE SHOULDN'T DO CONSTRUCTOR DI!!
        public MyMiddlewares(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await MiddleBefApp(context);
            await _next(context);
            await MiddleAftApp(context);
        }

        public async Task MiddleBefApp (HttpContext context)
        {
            Console.WriteLine("Middleware Before App\n");

            return ;
        }
        public async Task MiddleAftApp(HttpContext context)
        {
            Console.WriteLine("Middleware After App\n");
        }

    }

}
