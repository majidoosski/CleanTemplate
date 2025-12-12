using CleanTemplate.Application.Contracts;
using CleanTemplate.Application.DTOs;
using CleanTemplate.Application.Views;
using CleanTemplate.Domain.Common;
using CleanTemplate.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Services;

public class AuditableRepository<TEntity, TDTO, TView, TKey> : IAuditableRepository<TEntity, TKey>
    where TEntity : AuditableEntity
{
    private readonly ApplicationContext _context;
    public AuditableRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Task DeleteById(TKey id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllEntities()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetById(TKey id)
    {
        throw new NotImplementedException();
    }

    public Task<TKey> Insert(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
