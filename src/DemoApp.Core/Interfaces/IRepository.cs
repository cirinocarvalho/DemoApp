using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace DemoApp.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region " Async "
        //Task<TEntity> GetByIdAsync(int id);
        //Task<IReadOnlyList<TEntity>> ListAllAsync();
        //Task<TEntity> AddAsync(TEntity entity);
        //Task<TEntity> AddRangeAsync(IEnumerable<TEntity> entities);
        //Task UpdateAsync(TEntity entity);
        //Task DeleteAsync(TEntity entity);
        //Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        #endregion

        #region " Sync "
        //Search Records
        //TEntity Get(int id);
        //IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null,
        //                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //                          string includeProperties = null);
        //TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        
        TEntity GetById(object id);
        IEnumerable<TEntity> GetQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);

        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null);
        TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null);
        
        //Add Records
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Update Records
        void Update(TEntity entity);

        //Remove Records
        void Remove(object id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Save();
        #endregion

    }
}
