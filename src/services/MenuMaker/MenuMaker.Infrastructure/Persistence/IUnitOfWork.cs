using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Infrastructure.Persistence;
public interface IUnitOfWork<TContext>
{
    Task SaveAsync();
}
