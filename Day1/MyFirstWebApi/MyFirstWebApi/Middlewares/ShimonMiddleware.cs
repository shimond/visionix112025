using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyFirstWebApi.Middlewares
{
    public class ShimonMiddleware
    {
        private readonly RequestDelegate _next;

        public ShimonMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("1");
            await _next(httpContext);
            Console.WriteLine("2");
        }
    }

    public static class ShimonMiddlewareExtensions
    {
        public static IApplicationBuilder UseShimonMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShimonMiddleware>();
        }

        public static void Print(this string s, int count)
        {
            Console.WriteLine(s);
        }
    }
}
