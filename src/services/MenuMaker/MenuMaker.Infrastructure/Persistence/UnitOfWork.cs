using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Infrastructure.Persistence;
internal class UnitOfWork : IUnitOfWork<RecipesContext>
{
    private readonly RecipesContext _context;

    public UnitOfWork(RecipesContext context)
    {
        _context = context;
    }
    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }
}
