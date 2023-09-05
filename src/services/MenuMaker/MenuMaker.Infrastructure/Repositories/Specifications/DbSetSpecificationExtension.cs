using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Infrastructure.Repositories.Specifications;
public static class DbSetSpecificationExtension
{
    public static IQueryable<TEntity> QueryWithSpecification<TEntity>(
        this DbSet<TEntity> dbSet,
        ISpecification<TEntity> spec)
            where TEntity : class
    {
        {
            IQueryable<TEntity> query = dbSet;

            if (spec == null)
            {
                return query;
            }

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            query = query.Skip(spec.SkipValue ?? 0);
            
            query = spec.Includes.Aggregate(query, (current, include) => include(current));

            return query;
        }
    }
}
