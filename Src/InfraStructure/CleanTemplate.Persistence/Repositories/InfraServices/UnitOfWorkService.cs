using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Domain.Common;
using CleanTemplate.Persistence.Context;
using CleanTemplate.Persistence.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Repositories.InfraServices;

public class UnitOfWorkService : IUnitOfWorkRepository
{
    private readonly ApplicationContext _context;
    private ICurrentUserService _currentUserService;
    public UnitOfWorkService(ApplicationContext context, ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }
    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        _context.ChangeTracker.DetectChanges();

        _context.ChangeTracker.AutoDetectChangesEnabled = false;

        SetEntitiesChange(cancellationToken);

        int result = await _context.SaveChangesAsync(cancellationToken);

        _context.ChangeTracker.AutoDetectChangesEnabled = true;

        return result;
    }

    public Task RollBack()
    {
        throw new NotImplementedException();
    }

    public void SetEntitiesChange(CancellationToken cancellationToken)
    {
        foreach (var item in _context.ChangeTracker.Entries())
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (item.Entity is AuditableEntity entity)
            {
                if (item.State == EntityState.Added)
                {
                    entity.CreateDate = DateTime.Now;
                    entity.CreatedBy = _currentUserService.GetUserId();
                }
                if (item.State == EntityState.Modified)
                {
                    entity.ModifiedDate = DateTime.Now;
                    entity.ModifiedBy = _currentUserService.GetUserId();
                }
                if (item.State == EntityState.Deleted) 
                {
                    item.State = EntityState.Modified;
                    entity.IsDeleted = true;
                    entity.ModifiedDate = DateTime.Now;
                    entity.ModifiedBy = _currentUserService.GetUserId();
                }

            }

        }

    }
}
