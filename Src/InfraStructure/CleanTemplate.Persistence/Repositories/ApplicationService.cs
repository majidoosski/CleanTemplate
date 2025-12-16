using CleanTemplate.Application.Common.Exceptions;
using CleanTemplate.Application.Contracts;
using CleanTemplate.Domain.Common;
using CleanTemplate.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Repositories;

public class ApplicationService<TEntity, TKey> : IApplicationRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : notnull
{
    private readonly ApplicationContext _context;
    public ApplicationService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task DeleteById(TKey id)
    {
        var entity = await GetById(id);
        if (entity == null)
            throw new NotFoundException($"not found record in {nameof(TEntity)} whith {id}");
        entity.IsDeleted = true;
        await _context.SaveChangesAsync();

    }

    public async Task<IEnumerable<TEntity>> GetAllEntities()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetById(TKey id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<TKey> Insert(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity.Id;
    }

    public async Task Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
}
