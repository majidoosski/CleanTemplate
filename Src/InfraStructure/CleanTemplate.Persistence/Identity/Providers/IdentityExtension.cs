using CleanTemplate.Persistence.Context;
using CleanTemplate.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Identity.Providers
{
    public static class IdentityExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequiredLength =8;

            })
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders()
                .AddRoles<ApplicationRole>()
                ;
        }

    }
}
