using CleanTemplate.Application.Common.AppSettings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Identity.Providers;

public static class AuthorizationExtension
{
    public static void ConfigureAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Manager", options =>
            {
                options.RequireRole(AppRoles.SuperAdminRoleName);
            });
        });
    }
}
