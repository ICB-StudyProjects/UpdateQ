namespace UpdateQ.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> condition);

        T GetById<P>(P id) where P : struct;
        T Get(Expression<Func<T, bool>> condition);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> condition);
    }
}
