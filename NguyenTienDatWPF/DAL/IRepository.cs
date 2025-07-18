using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
    }
}
