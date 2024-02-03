using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MenuMaker.Infrastructure.Repositories.Specifications;
public class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }

    public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; } =
        new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

    public Expression<Func<T, object>> OrderBy { get; private set; }
    public Expression<Func<T, object>> OrderByDescending { get; private set; }
    public int? SkipValue { get; private set; }
    public int? TakeValue { get; private set; }

    public void AddInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    public void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }

    public void Skip(int skip)
    {
        if (skip >= 0)
        {
            SkipValue = skip;
        }
    }

    public void Take(int take)
    {
        if (take >= 0) 
        {
            TakeValue = take;
        }
    }
}
