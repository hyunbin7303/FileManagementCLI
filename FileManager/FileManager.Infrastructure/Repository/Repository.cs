using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public EntityEntry<T> Add(T entity)
        {
            return _context.Set<T>().Add(entity);
        }
        public ValueTask<EntityEntry<T>> AddAsync(T entity)
        {
            return _context.Set<T>().AddAsync(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public async Task AddRangeAsnc(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
