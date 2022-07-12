using System.Net;
using Meter_API.Domain.response;
using Microsoft.AspNetCore.Diagnostics;

namespace Meter_API.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new MeterResponse()
                        {
                            StatusCode = context.Response.StatusCode,
                            Error = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}