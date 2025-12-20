namespace CleanTemplate.WebApi.Providers;


/// <summary>
/// 
/// </summary>
public static class HealthCheckExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureHealthCheck(this IServiceCollection services , IConfiguration configuration)
    {

        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        if (connectionString == null)
            throw new ApplicationException("connection string not found!!!!!");

        services.AddHealthChecks()
                .AddSqlServer(connectionString);
                        
    }
}
