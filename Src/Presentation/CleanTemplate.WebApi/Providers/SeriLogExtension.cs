using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace CleanTemplate.WebApi.Providers;

public static class SeriLogExtension
{
    public static void ConfigureSerilog(this IServiceCollection services, IConfiguration configuration)
    {
        var loggerSetting = new LoggerSetting();

        services.AddSerilog(options =>
        {
            options.ReadFrom.Settings(loggerSetting);
        });
    }
}

public class LoggerSetting : ILoggerSettings
{
    public void Configure(LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration
         .MinimumLevel.Debug()
         .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
         .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
         .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
         .MinimumLevel.Override("AspNetCore.Routing", LogEventLevel.Warning)
         .MinimumLevel.Override("Swagger", LogEventLevel.Warning)
         .WriteTo
         .Console(Serilog.Events.LogEventLevel.Information, "[{Timestamp:HH:mm:ss} {Level:u3}][Machine:{MachineName}][ThreadId:{ThreadId}][ThreadName:{ThreadName}] {Message:lj}{NewLine}{Exception}", theme: AnsiConsoleTheme.Sixteen)
         .Enrich.FromLogContext()
         .Enrich.WithThreadId()
         .Enrich.WithThreadName()
         .Enrich.WithMachineName()
         .WriteTo.File("./Logs/log-.txt", LogEventLevel.Error, "[{Timestamp:HH:mm:ss} {Level:u3}][Machine:{MachineName}][ThreadId:{ThreadId}][ThreadName:{ThreadName}] {Message:lj}{NewLine}{Exception}", rollingInterval:RollingInterval.Day)
         .Filter.ByExcluding("RequestPath like '/swagger%'");
    }
}



