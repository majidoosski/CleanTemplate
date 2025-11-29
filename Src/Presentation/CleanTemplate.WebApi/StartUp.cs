using CleanTemplate.Application;
using CleanTemplate.Persistence;
using CleanTemplate.WebApi.Providers;

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
            services.AddPersistence(_configuration);
            services.AddApplication(_configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.ConfigureSwaggerServices();
        }

        public void Configure(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwagger(options => options.RouteTemplate = "api-docs/{documentName}/swagger.json");
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/api-docs/v1/swagger.json", "v1"); });
            app.MapControllers();
        }
        
    }
}
