using MenuMaker.Infrastructure.Entities;
using MenuMaker.Infrastructure.Repositories.Specifications;
using System.Linq.Expressions;

namespace MenuMaker.Infrastructure.Repositories;
public interface IGenericRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    Task<TEntity> AddAsync(TEntity entity);
    void Delete(TEntity entity);
    Task DeleteAsync(TId id);
    Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);
    Task<bool> ExistsAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity?> GetAsync(TId id, params Expression<Func<TEntity, object>>[] includeProperties);
    void Update(TEntity entity);
    void UpdateValues(TEntity existingEntityToUpdate, TEntity entityWithUpdates);
    Task<IEnumerable<TEntity>> FindWithSpecification(ISpecification<TEntity> specification = null);
    Task<int> SaveChangesAsync();
    Task<TEntity> ReloadAsync(TEntity entity);
    void ClearTracker();
}