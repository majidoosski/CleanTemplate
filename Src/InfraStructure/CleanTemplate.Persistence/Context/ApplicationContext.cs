using CleanTemplate.Domain.Entities;
using CleanTemplate.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanTemplate.Persistence.Context;

public class ApplicationContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected ApplicationContext()
    {
    }

    public DbSet<ApplicationPermissions> ApplicationPermissions { get; set; }
    public DbSet<ApplicationRolePermissions> ApplicationRolePermissions { get; set; }

}
