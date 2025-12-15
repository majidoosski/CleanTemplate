using CleanTemplate.Application.Contracts;
using CleanTemplate.Persistence.Identity.Services;
using CleanTemplate.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Providers;

public static class ServiceRegisterExtension
{
    public static void AddInfraStructureServices(this IServiceCollection services)
    {
        #region Transuent
        services.AddTransient<IAuthenticationRepository,AuthenticationServices>();
        services.AddTransient<ICurrentUserService, CurrnetUserService>();
        #endregion

        #region Scoped
        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkService>();

        #endregion
    }
}
