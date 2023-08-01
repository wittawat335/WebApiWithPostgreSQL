using Core.Domain.RepositoryContracts;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly sampleDBContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(sampleDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> AsQueryable(Expression<Func<T, bool>>? filter = null, int? skip = null, int? take = null)
        {
            try
            {
                IQueryable<T> query = filter == null ? _dbSet : _dbSet.Where(filter);

                if (skip != null)
                    query = query.Skip(skip.Value);

                if (take != null)
                    query = query.Take(take.Value);

                return query;
            }
            catch
            {
                throw;
            }
        }
    }
}
