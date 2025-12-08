using Serilog;

namespace CleanTemplate.WebApi.Providers;

public static class SeriLogExtension
{
    public static void ConfigureSerilog(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddSerilog(options =>
        {
            options.ReadFrom.Configuration(configuration);
        });
    }
}
