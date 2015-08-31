using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RemindersApp.DAL.Abstract
{
    public interface IGenericRepository<T> where T : class

    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> GetAll();
        T Single(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>>  predicate);
        T Find(Expression<Func<T, bool>> predicate);
        T GetbyId(int id);
        

        void Add(T entity);
        void Delete(T entity);

    }
}
