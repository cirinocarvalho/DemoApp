using DemoApp.Core.Entities;
using DemoApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AutoEmailDbContext _dbContext;
        private IDbContextTransaction _dbTran;
        private IRepository<AppEmail> _owner;

        public RepositoryWrapper(AutoEmailDbContext context)
        {
            _dbContext = context;
        }

        public IRepository<AppEmail> Owner
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new Repository<AppEmail>(_dbContext);
                }

                return _owner;
            }
        }

        #region " DB Transaction "
        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }

        public void BeginTransaction()
        {
            try
            {
                _dbTran = _dbContext.Database.BeginTransaction();
            }
            catch (Exception e)
            {

            }

        }

        public void CommitTransaction()
        {
            try
            {
                _dbTran.Commit();
            }
            catch (Exception e)
            {

            }

        }

        public void RollbackTransaction()
        {
            try
            {
                _dbTran?.Rollback();
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
