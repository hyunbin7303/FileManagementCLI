using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRepository<T>  where T : class
    {
        public EntityEntry<T> Add(T entity);
        public ValueTask<EntityEntry<T>> AddAsync(T entity);
        public void AddRange(IEnumerable<T> entities);
        public  Task AddRangeAsnc(IEnumerable<T> entities);
        public IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        public IEnumerable<T> GetAll();
        public T FindById(int id);
        public  Task<T> FindByIdAsync(int id);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
        public int SaveChanges();
        public Task<int> SaveChangesAsync();
    }
}
