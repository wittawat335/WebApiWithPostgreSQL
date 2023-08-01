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
        IQueryable<T> AsQueryable(Expression<Func<T, bool>>? filter = null, int? skip = null, int? take = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        void Add(T model);
        void AddRange(List<T> model);
        void Update(T model);
        void Delete(T model);
        void DeleteRange(List<T> model);
        Task SaveChangesAsync();
    }
}
