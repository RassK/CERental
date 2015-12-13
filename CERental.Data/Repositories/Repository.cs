using CERental.Core;
using CERental.Core.Contract;
using CERental.Core.Contract.Repository;
using CERental.Core.Domain;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace CERental.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            DbContext = IoC.Resolve<IDbContext>() as DbContext;
            DbSet = DbContext.Set<T>();
        }

        public IQueryable<T> All
        {
            get { return DbSet; }
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            return includeProperties.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(DbSet,
                (current, includeProperty) => current.Include(includeProperty));
        }

        public T FindById(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = DbContext.Entry(entity);
            if (entry.State != EntityState.Detached)
                entry.State = EntityState.Added;
            else DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
                DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = DbContext.Entry(entity);
            if (entry.State != EntityState.Deleted)
                entry.State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = FindById(id);
            if (entity == null) return;
            Delete(entity);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}