using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.RepositoryContracts
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> AsQueryable(Expression<Func<T, bool>>? filter = null,
          int? skip = null, int? take = null);
    }
}
