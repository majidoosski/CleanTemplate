//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using Serilog;
//using System.IO.Pipelines;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace CleanTemplate.WebApi.Middlewares
//{
//    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
//    public class LoggingMiddleWare
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<LoggingMiddleWare> _logger;

//        public LoggingMiddleWare(RequestDelegate next, ILogger<LoggingMiddleWare> logger)
//        {
//            _next = next;
//            _logger = logger;
//        }

//        public async Task Invoke(HttpContext httpContext)
//        {
//            //Log Request
//            await LogRequest(httpContext);

//            await _next(httpContext);

//            //Log Response
//            await LogResponse(httpContext);

//        }

//        private async Task LogRequest(HttpContext context)
//        {

//            try
//            {

//            }
//            catch (Exception)
//            {



//                string headers = string.Empty;
//                var requestBodyStream = new MemoryStream();

//                foreach (var key in context.Request.Headers.Keys)
//                {
//                    headers += key + "=" + context.Request.Headers[key] + Environment.NewLine;
//                }

//                context.Request.EnableBuffering();

//                 var requestBody = await new StreamReader(context.Request.Body, Encoding.UTF8).ReadToEndAsync();
//                 await context.Request.Body.CopyToAsync(requestBody);
//                 context.Request.Body.Position = 0;

//                log.RequestTimestamp = DateTime.Now;
//                log.RequestUri = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
//                log.IpAddress = $"{context.Request.Host.Host}";
//                log.RequestMethod = $"{context.Request.Method}";
//                log.Machine = Environment.MachineName;
//                log.RequestContentType = context.Request.ContentType;
//                log.RequestBody = ReadStreamInChunks(requestStream);
//                //log.RequestBody = FormatRequest(context.Request);
//                log.RequestHeaders = headers;
//            }

//            var user = context.User.Identity?.Name;
//            var Token = context.GetTokenAsync("access-Token");

//        }
//        private async Task LogResponse(HttpContext context)
//        {

//        }



//    }

//    // Extension method used to add the middleware to the HTTP request pipeline.
//    public static class LoggingMiddleWareExtensions
//    {
//        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
//        {
//            return builder.UseMiddleware<LoggingMiddleWare>();
//        }
//    }
//}
