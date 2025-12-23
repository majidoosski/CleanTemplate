using CleanTemplate.Application;
using CleanTemplate.Application.Common.AppSettings;
using CleanTemplate.Persistence;
using CleanTemplate.Persistence.Identity.Entities;
using CleanTemplate.WebApi.Middlewares;
using CleanTemplate.WebApi.Providers;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using System.Net;

namespace CleanTemplate.WebApi
{
    public class StartUp
    {
        private readonly IConfiguration _configuration;

        public StartUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddPersistence(_configuration);
            services.AddApplication(_configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.ConfigureSwaggerServices();
            services.ConfigureSerilog(_configuration);
            services.ConfigurCorsPolicy(_configuration);
            services.ConfigureHealthCheck(_configuration);
        }

        public void Configure(WebApplication app)
        {
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("speceficOrigin");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger(options => options.RouteTemplate = "api-docs/{documentName}/swagger.json");
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/api-docs/v1/swagger.json", "v1"); });
            app.UseErrorHandler();
            app.MapControllers();
            app.UseHealthChecks("/api/health", options: new HealthCheckOptions()
            {
                ResultStatusCodes = new Dictionary<HealthStatus, int>
                {
                    {HealthStatus.Healthy , 200},
                    {HealthStatus.Unhealthy , 500 },
                    {HealthStatus.Degraded ,304},
                },
                //ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/healthcheck-ui";
                //options.AddCustomStylesheet("./HealthCheck/Custom.css");
            });
        }
        
    }
}
