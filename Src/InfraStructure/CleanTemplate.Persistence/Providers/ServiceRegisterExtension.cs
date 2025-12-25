using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Application.Contracts.Repositories;
using CleanTemplate.Persistence.Identity.Services;
using CleanTemplate.Persistence.Repositories.InfraServices;
using CleanTemplate.Persistence.Repositories.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTemplate.Persistence.Providers;

public static class ServiceRegisterExtension
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        #region Transient
        services.AddTransient<IAuthenticationRepository, AuthenticationServices>();
        services.AddTransient<ICurrentUserService, CurrnetUserService>();
        services.AddTransient<IProductRepository, ProductService>();
        #endregion
        #region Scoped
        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkService>();

        #endregion
        #region SingleTon
        #endregion
    }
}
