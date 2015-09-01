using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using RemindersApp.DAL.Abstract;

namespace RemindersApp.DAL.Concrete
{
    class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public EfGenericRepository(DbSet<T> dbSet )
        {
            _dbSet = dbSet;
        }

#region IGeneric Repository implementation
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Find(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetbyId(int id)
        {
            return _dbSet.Find(id);
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Single(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }
#endregion
    }
}
