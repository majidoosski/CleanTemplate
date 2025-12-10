using CleanTemplate.Application.Common.Exceptions;
using CleanTemplate.Application.Wrappers;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Net;
using System.Text.Json;

namespace CleanTemplate.WebApi.Middlewares;

#region NewWayErrorHandling

// I use this way and config it in StartUp.cs
public static class ErrorHandlerMiddleWare
{

    public static void UseErrorHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(configure =>
        {
            configure.Run(async context =>
            {

                var logger=context.RequestServices.GetRequiredService<Serilog.ILogger>();

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature == null) return;

                //Use logger from serilog

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = contextFeature.Error switch
                {
                    Application.Common.Exceptions.ApplicationException => (int)HttpStatusCode.BadRequest,
                    BadRequestException => (int)HttpStatusCode.BadRequest,
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var response = new ApplicationResponse<string>()
                {
                    Succeeded = false,
                    Message = contextFeature.Error.GetBaseException().Message,

                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));

            });

        });
    }

}

#endregion

#region OldWayErrorHandling

// for use this way you must configure "app.UseErrorHandler()" in startup.cs or program.cs
//public class ErrorMiddleWare
//{
//    private readonly RequestDelegate _next;

//    public ErrorMiddleWare(RequestDelegate next)
//    {
//        _next = next;
//    }

//    public async Task InokeAsync(HttpContext context)
//    {
//        try
//        {
//            await _next(context);
//        }
//        catch (Exception ex)
//        {
//            var response = context.Response;
//            response.ContentType = "application/json";
//            var responseModel = new ApplicationResponse<string>() { Message = ex.Message, Succeeded = false };


//            response.StatusCode = ex switch
//            {
//                BadRequestException => (int)HttpStatusCode.BadRequest,
//                NotFoundException => (int)HttpStatusCode.NotFound,
//            };

//            var result=JsonSerializer.Serialize(responseModel);
//            await response.WriteAsync(result);
//        }

//    }


//}

//public static class ErrorMiddleWareExtension
//{
//    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
//    {
//       return  app.UseMiddleware<ErrorMiddleWare>();
//    }
//}
#endregion
