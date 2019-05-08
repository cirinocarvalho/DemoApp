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
        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        Task<IEnumerable<TEntity>> GetByConditionAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        #endregion

        #region " Sync "

        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        IEnumerable<TEntity> GetByCondition(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        
        //Add Records
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Update Records
        void Update(TEntity entity);

        //Remove Records
        void Delete(object id);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        #endregion

    }
}
