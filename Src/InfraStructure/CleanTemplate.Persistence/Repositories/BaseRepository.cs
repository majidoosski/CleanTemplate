using CleanTemplate.Application.Contracts;
using CleanTemplate.Domain.Common;
using CleanTemplate.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Repositories;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : BaseEntity
{
    private readonly ApplicationContext _context;
    public BaseRepository(ApplicationContext context)
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
