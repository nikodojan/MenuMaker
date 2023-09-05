using MenuMaker.Domain.Common;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MenuMaker.Infrastructure.Repositories;
public class GenericRepository<TEntity, TId, TDbContext> 
    : IGenericRepository<TEntity, TId> where TId : notnull
        where TEntity : Entity<TId>
        where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    /// <summary>
    /// Checks if an entity exists in the database without loading it to context.
    /// </summary>
    /// <param name="entity">Id of the entity to check existance for</param>
    /// <returns><see cref="true"/> if the entity exists otherwise false</returns>
    public async Task<bool> ExistsAsync(TId id)
    {
        return await _dbSet.AnyAsync(e => e.Id.Equals(id));
    }

    /// <summary>
    /// Adds an entity.
    /// </summary>
    /// <param name="entity">The entity to add</param>
    /// <returns>The entity that was added</returns>
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    /// <summary>
    /// Updates an entity which is not known by <see cref="DbContext"/>, aka has not been fetched by e.g <see cref="GetAsync(TId, Expression{Func{TEntity, object}}[])"/> or <see cref="GetManyAsync(Expression{Func{TEntity, bool}}?, Func{IQueryable{TEntity}, IOrderedQueryable{TEntity}}?, int?, int?, Expression{Func{TEntity, object}}[])"/>.
    /// If the entity is using auto incremented keys and contain an Id then the entity is updated in the database. If the entity has no Id then it is added to the database. If the entity is already known by <see cref="DbContext"/> 
    /// then an exception will be throw about an entity with same key is already being tracked.
    /// Be aware that navigation properties are also added/updated in the same manner.
    /// </summary>
    /// <param name="entity">The entity to update</param>
    /// <returns>The entity that was updated</returns>
    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    /// <summary>
    /// Sets the property values of the given entity with updates at the existing entity to update
    /// </summary>
    /// <param name="existingEntityToUpdate">Existing entity known by <see cref="DbContext"/> to update.</param>
    /// <param name="entityWithUpdates">The entity not known by <see cref="DbContext"/> which have updated properties which needs to be set on the existing entity.</param>
    public void UpdateValues(TEntity existingEntityToUpdate, TEntity entityWithUpdates)
    {
        _dbContext.Entry(existingEntityToUpdate).CurrentValues.SetValues(entityWithUpdates);
    }

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete</param>
    /// <returns><see cref="Task"/></returns>
    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete</param>
    /// <returns><see cref="Task"/></returns>
    public Task DeleteAsync(TId id)
    {
        return DeleteManyAsync(e => e.Id.Equals(id));
    }

    /// <summary>
    /// Deletes entities based on a condition.
    /// </summary>
    /// <param name="filter">The condition the entities must fulfil to be deleted</param>
    /// <returns><see cref="Task"/></returns>
    public Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
    {
        var entities = _dbSet.Where(filter);

        _dbSet.RemoveRange(entities);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Gets a collection of all entities.
    /// </summary>
    /// <returns>A collection of all entities</returns>
    public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;
        if (includeProperties != null)
        {
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Gets an entity by ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve</param>
    /// <returns>The entity object if found, otherwise null</returns>
    public async Task<TEntity?> GetAsync(TId id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        if (id == null) return null;

        IQueryable<TEntity> query = _dbSet;
        if (includeProperties != null)
        {
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> FindWithSpecification(ISpecification<TEntity> specification = null)
    {
        return await _dbSet.QueryWithSpecification<TEntity>(specification).ToListAsync();
    }

    /// <summary>
    /// Gets a collection of entities based on the specified criteria.
    /// </summary>
    /// <param name="filter">The condition the entities must fulfil to be returned</param>
    /// <param name="orderBy">The function used to order the entities</param>
    /// <param name="top">The number of records to limit the results to</param>
    /// <param name="skip">The number of records to skip</param>
    /// <param name="includeProperties">Any other navigation properties to include when returning the collection</param>
    /// <returns>Total count of entities and a collection of entities</returns>
    //public async Task<(int totalCount, IEnumerable<TEntity> entities)> GetManyAsync(
    //    Expression<Func<TEntity, bool>>? filter = null,
    //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
    //    int? top = null,
    //    int? skip = null,
    //    params Expression<Func<TEntity, object>>[] includeProperties)
    //{
    //    IQueryable<TEntity> countQuery = _dbSet;
    //    if (filter != null)
    //    {
    //        countQuery = countQuery.Where(filter);
    //    }

    //    var totalCount = await countQuery.CountAsync();
    //    // TODO: Support order by property name string
    //    var entities = await _dbSet.QueryMany(filter, orderBy, top, skip, includeProperties).ToListAsync();
    //    return (totalCount, entities);
    //}
}
