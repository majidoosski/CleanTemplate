using CleanTemplate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Contracts;

public interface IApplicationRepository<TEntity, TKey> 
    where TEntity : BaseEntity<TKey>
    where TKey : notnull
    
{
    public Task<IEnumerable<TEntity>> GetAllEntities();
    public Task<TEntity?> GetById(TKey id);
    public Task Update(TEntity entity);
    public Task DeleteById(TKey id);
    public Task<TKey> Insert(TEntity entity);
}
