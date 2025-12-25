using CleanTemplate.Domain.Common;

namespace CleanTemplate.Application.Contracts.ApplicationContracts;

public interface IApplicationRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : notnull

{
    public Task<IEnumerable<TEntity>> GetAll();
    public Task<TEntity?> GetById(TKey id);
    public Task Update(TEntity entity);
    public Task DeleteById(TKey id);
    public Task<TKey> Insert(TEntity entity);
}
