using CleanTemplate.Application.Common.AppSettings;
using CleanTemplate.Persistence.Context;
using CleanTemplate.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Providers;

public static class SeedDataExtension
{

    public static async Task SeedDataAsync(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        //first apply migrations to dataBase 
        await context.Database.MigrateAsync();
        #region CreateUserAndRole
        var userManger = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
        var appRoles = new[]
        {
            AppRoles.SuperAdminRoleName,
            AppRoles.AdminRoleName,
            AppRoles.DefaultRoleName,
        };
        foreach (var item in appRoles)
        {
            var role = await roleManger.FindByNameAsync(item);
            if(role is null)
            {
                var creatResult = await roleManger.CreateAsync(new ApplicationRole() { Name =item});
                if (!creatResult.Succeeded)
                    throw new Exception($"Creation role '{item}' failed");

            }

        }
        if ( !await userManger.Users.AnyAsync()){
            var user = new ApplicationUser()
            {
                FirstName = "Majid",
                LastName = "Akbari",
                UserName = "Majidoosski",
            };
            await userManger.CreateAsync(user, "M@j1551687");
            var result = await userManger.IsInRoleAsync(user, AppRoles.SuperAdminRoleName);
            if (!result)
            {
                 await userManger.AddToRoleAsync(user, AppRoles.SuperAdminRoleName);
            }
        }
        #endregion
    }
}
