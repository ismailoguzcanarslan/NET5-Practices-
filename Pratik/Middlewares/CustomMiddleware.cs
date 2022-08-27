using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Pratik.Services;
using Pratik.Entities;

namespace Pratik.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        //Scope Servisler Her req de yaratılır.
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILoggerService<Log> loggerService)
        {
            string message = string.Empty;
            var watch = Stopwatch.StartNew();

            try
            {
                Log request = new Log();
                request.LogType = Common.LogType.Request;
                request.HttpMethod = Common.HttpMethodEnum.Put; //context.Request.Method.ToString();
                request.Path = context.Request.Path.ToString();
                request.Date = DateTime.Now;
                loggerService.Write(request);
                //Console.WriteLine(message);
                await _next(context);
                watch.Stop();
                Log response = new Log();
                response.LogType = Common.LogType.Response;
                response.HttpMethod = Common.HttpMethodEnum.Post;
                response.Path = "RESPONSE: " + context.Response.StatusCode.ToString();
                response.Date = DateTime.Now;
                response.LogType = Common.LogType.Response;
                loggerService.Write(response);
                //Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
                
                Console.WriteLine(message);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            var message = "[Response][ERROR] HTTP" + context.Request.Method + " - " + context.Request.Path + " - " + context.Response.StatusCode + " - ErrorMessage: " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds;
            Console.WriteLine(message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtention
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
