using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Core.Entities;
using DemoApp.Core.Interfaces;

namespace DemoApp.Infrastructure.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AutoEmailDbContext _dbContext;
        private IRepository<AppEmail> _owner;

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

        public RepositoryWrapper(AutoEmailDbContext context)
        {
            _dbContext = context;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
