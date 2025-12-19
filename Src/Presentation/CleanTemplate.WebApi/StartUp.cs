using CleanTemplate.Application;
using CleanTemplate.Application.Common.AppSettings;
using CleanTemplate.Persistence;
using CleanTemplate.Persistence.Identity.Entities;
using CleanTemplate.WebApi.Middlewares;
using CleanTemplate.WebApi.Providers;
using Serilog;

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
            
        }
        
    }
}
