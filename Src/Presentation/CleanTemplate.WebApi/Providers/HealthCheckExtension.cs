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


        services.AddHealthChecksUI(opt =>
        {
            opt.SetEvaluationTimeInSeconds(10); //time in seconds between check    
            opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks    
            opt.SetApiMaxActiveRequests(1); //api requests concurrency    
            opt.AddHealthCheckEndpoint("feedback api", "/api/health"); //map health check api 

        }).AddInMemoryStorage();
          

    }
}
