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

            return services;
        }

        public static async Task InitPersistence(this IServiceProvider service, IConfiguration configuration)
        {

        }
    }
}
