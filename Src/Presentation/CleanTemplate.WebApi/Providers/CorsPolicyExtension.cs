using CleanTemplate.Application.Common.AppSettings;

namespace CleanTemplate.WebApi.Providers;

public static class CorsPolicyExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void ConfigurCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddCors(options =>
        {
            options.AddPolicy(name:"speceficOrigin", policyOptions =>
            {
                //change this origins address 
                policyOptions.WithOrigins("https://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .SetPreflightMaxAge(TimeSpan.FromMinutes(15));

            });
        });

    }

}
