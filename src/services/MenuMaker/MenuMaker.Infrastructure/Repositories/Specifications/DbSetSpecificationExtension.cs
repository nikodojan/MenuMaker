using Microsoft.EntityFrameworkCore;

namespace MenuMaker.Infrastructure.Repositories.Specifications;
public static class DbSetSpecificationExtension
{
    public static IQueryable<TEntity> QueryWithSpecification<TEntity>(
        this DbSet<TEntity> dbSet,
        ISpecification<TEntity>? spec)
            where TEntity : class
    {
        {
            IQueryable<TEntity> query = dbSet;

            if (spec == null)
                return query;            

            if (spec.Criteria is not null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.SkipValue is not null)
            {
                query = query.Skip(Convert.ToInt16(spec.SkipValue));
            }
            
            if (spec.TakeValue is not null)
            {
                query = query.Take(Convert.ToInt32(spec.TakeValue));
            }

            query = spec.Includes.Aggregate(query, (current, include) => include(current));

            return query;
        }
    }
}
