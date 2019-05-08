using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Core.Entities;

namespace DemoApp.Core.Interfaces
{
    public interface IRepositoryWrapper : IDisposable
    {
        IRepository<AppEmail> Owner { get; }
        void SaveChanges();
        Task SaveChangesAsync();

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
