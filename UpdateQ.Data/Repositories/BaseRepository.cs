namespace UpdateQ.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using UpdateQ.Data.Infrastructure;

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private UpdateQContext dbContext;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory { get; private set; }

        protected UpdateQContext DbContext
            => this.dbContext ?? (this.dbContext = this.DbFactory.Init());

        public BaseRepository(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
            this.dbSet = this.DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            this.dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            this.dbSet.Attach(entity);
            this.DbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> objectsToDel = this.dbSet.Where(condition).AsEnumerable();
            foreach (T obj in objectsToDel)
            {
                this.dbSet.Remove(obj);
            }
        }

        public virtual T GetById(int id) 
            => this.dbSet.Find(id);

        public virtual T GetById(Guid id)
            => this.dbSet.Find(id);

        public virtual T Get(Expression<Func<T, bool>> condition)
            => this.dbSet.Where(condition).FirstOrDefault<T>();

        public virtual IEnumerable<T> GetAll()
            => this.dbSet.ToList();

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> condition)
            => this.dbSet.Where(condition).ToList();
        #endregion
    }
}
