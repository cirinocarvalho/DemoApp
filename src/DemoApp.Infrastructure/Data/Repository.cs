using DemoApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace DemoApp.Infrastructure.Data
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AutoEmailDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AutoEmailDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        //#region " Async Methods "
        //public virtual async Task<TEntity> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<TEntity>().FindAsync(id);
        //}

        //public async Task<IReadOnlyList<TEntity>> ListAllAsync()
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        //public async Task<TEntity> AddAsync(TEntity entity)
        //{
        //    _dbContext.Set<T>().Add(entity);
        //    await _dbContext.SaveChangesAsync();

        //    return entity;
        //}

        //public async Task<TEntity> AddRangeAsync(IEnumerable<TEntity> entities) 
        //{
        //    _dbContext.AddRange(entities);
        //    await _dbContext.SaveChangesAsync();

        //    return entities;
        //} 

        //public async Task UpdateAsync(TEntity entity)
        //{
        //    _dbContext.Attach(entity);
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(TEntity entity)
        //{
        //    _dbContext.Set<TEntity>().Remove(entity);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    _dbContext.RemoveRange(entities);
        //    await _dbContext.SaveChangesAsync();
        //}

        //#endregion Async Methods

        #region " Sync Methods "
        //public TEntity Get(int id) => _dbSet.Find(id);

        //public IEnumerable<TEntity> GetAll() => _dbSet.AsNoTracking().ToList();

        //public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null,
        //                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //                                          string includeProperties = null)
        //{
        //    IQueryable<TEntity> query = _dbSet;

        //    if (filter != null)
        //    {
        //        query = query.AsNoTracking().Where(filter);
        //    }

        //    if (includeProperties != null)
        //    {
        //        query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        //            .Aggregate(query, (current, includeProperty) => current.AsNoTracking().Include(includeProperty));
        //    }

        //    return orderBy != null ? orderBy(query).AsNoTracking().ToList() : query.AsNoTracking().ToList();
        //}

        //public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => _dbSet.AsNoTracking().SingleOrDefault(predicate);

        public virtual IEnumerable<TEntity> GetQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return GetQueryable(orderBy: orderBy, includeProperties: includeProperties, skip: skip, take: take);
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            return GetQueryable(filter: filter, orderBy: orderBy, includeProperties: includeProperties).FirstOrDefault();
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            return GetQueryable(filter: filter, includeProperties: includeProperties).SingleOrDefault();
        }

        public void Add(TEntity entity) => _dbSet.Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }


        public virtual void Remove(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        #endregion

        #region " Dispose "

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
