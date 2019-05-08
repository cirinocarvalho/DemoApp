using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Core.Entities;

namespace DemoApp.Core.Interfaces
{
    public interface IRepositoryWrapper
    {
        IRepository<AppEmail> Owner { get; }
        void Save();
        Task SaveAsync();
    }
}
