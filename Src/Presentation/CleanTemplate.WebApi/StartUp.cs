using CleanTemplate.Application;
using CleanTemplate.Application.Common.AppSettings;
using CleanTemplate.Persistence;
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
            services.AddAuthentication();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.ConfigureSwaggerServices();
            services.ConfigureSerilog(_configuration);
        }

        public void Configure(WebApplication app)
        {
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger(options => options.RouteTemplate = "api-docs/{documentName}/swagger.json");
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/api-docs/v1/swagger.json", "v1"); });
            app.UseErrorHandler();
            app.MapControllers();
            
        }
        
    }
}
