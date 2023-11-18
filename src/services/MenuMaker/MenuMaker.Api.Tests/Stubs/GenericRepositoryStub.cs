using MenuMaker.Domain.Common;
using MenuMaker.Infrastructure.Repositories;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MenuMaker.Api.Tests.Stubs;
internal class GenericRepositoryStub<TEntity, TId, TDbContext>
    : IGenericRepository<TEntity, TId> where TId : notnull
        where TEntity : Entity<TId>
        where TDbContext : DbContext
{
    private List<TEntity> _entities;

    public GenericRepositoryStub()
    {
        _entities = new List<TEntity>();
    }

    public Task<TEntity> AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> FindWithSpecification(ISpecification<TEntity> specification = null)
    {
        return new List<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return new List<TEntity>();
    }

    public async Task<TEntity?> GetAsync(TId id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        if (id == null) return null;

        IQueryable<TEntity> query = _entities.AsQueryable<TEntity>();
        if (includeProperties != null)
        {
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        
        return query.FirstOrDefault<TEntity>(e=>e.Id.Equals(id));
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateValues(TEntity existingEntityToUpdate, TEntity entityWithUpdates)
    {
        throw new NotImplementedException();
    }
}
