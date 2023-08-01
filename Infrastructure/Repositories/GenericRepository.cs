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
        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }
        public void Add(T model)
        {
            _dbSet.Add(model);
        }

        public void AddRange(List<T> model)
        {
            _dbSet.AddRange(model);
        }

        public void Update(T model)
        {
            _dbSet.Update(model);
        }

        public void Delete(T model)
        {
            _dbSet.Remove(model);
        }
     
        public void DeleteRange(List<T> model)
        {
            _dbSet.RemoveRange(model);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
