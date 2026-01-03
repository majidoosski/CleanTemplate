using CleanTemplate.Application.Services.Product;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanTemplate.Application;

public static class ApplicationSetup
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        });

        services.AddScoped(typeof(ProductService));
        services.AddValidatorsFromAssemblies(
                AppDomain.CurrentDomain.GetAssemblies()
            );


        return services;
    }
}
