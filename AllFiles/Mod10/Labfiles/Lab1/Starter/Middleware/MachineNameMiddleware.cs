using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlueYonder.Flights.Service.Middleware
{
    public class MachineNameMiddleware
    {
        private readonly RequestDelegate _next;

        public MachineNameMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("X-BlueYonder-Server", Environment.MachineName);

            await _next(httpContext);
        }
    }

    public static class MachineNameMiddlewareExtensions
    {
        public static IApplicationBuilder UseMachineNameMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MachineNameMiddleware>();
        }
    }
}