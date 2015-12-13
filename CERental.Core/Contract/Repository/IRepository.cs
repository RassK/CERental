using System;
using System.Linq;
using System.Linq.Expressions;

namespace CERental.Core.Contract.Repository
{
    public interface IRepository : IDisposable
    {

    }

    public interface IRepository<T> : IRepository
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T FindById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Save();
    }
}