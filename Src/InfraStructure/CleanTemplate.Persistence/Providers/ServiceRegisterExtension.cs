using CleanTemplate.Application.Contracts;
using CleanTemplate.Persistence.Identity.Services;
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
        services.AddTransient<IAuthenticationService,AuthenticationServices>();
    }
}
