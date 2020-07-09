using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SS.Data.Interfaces
{
    public interface IDataRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        bool ContextUpdated();
        Task<bool> SaveAll();

        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> FindMany(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}