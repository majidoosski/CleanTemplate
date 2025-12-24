using CleanTemplate.Domain.Entities;
using CleanTemplate.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanTemplate.Persistence.Context;

public class ApplicationContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(assembly:Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public DbSet<Product> Products { get; set; }

}
