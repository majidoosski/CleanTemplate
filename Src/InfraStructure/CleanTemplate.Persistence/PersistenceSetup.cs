using CleanTemplate.Persistence.Context;
using CleanTemplate.Persistence.Identity.Providers;
using CleanTemplate.Persistence.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence
{
    public static class PersistenceSetup
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("CleanTemplate.Persistence"));
            });

            services.ConfigureIdentity();
            services.ConfigureAuthentication(configuration);
            services.AddInfraStructureServices();
            return services;
        }

        public static async Task InitPersistence(this IServiceProvider provider, IConfiguration configuration)
        {
            await provider.SeedDataAsync();

            //var provider = service.GetRequiredService<ApplicationContext>();
            //var context=provider
            ////applying migrations to dataBase
            //await context.Database.MigrateAsync();


        }
    }
}
