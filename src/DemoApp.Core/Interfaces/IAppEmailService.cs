using System.Threading.Tasks;
using System.Collections.Generic;
using DemoApp.Core.Entities;

namespace DemoApp.Core.Interfaces
{
    public interface IAppEmailService
    {
         void Save();
         IEnumerable<AppEmail> GetEmailList();
         Task<IEnumerable<AppEmail>> GetEmailLists();
         Task SaveAsync();

    }
}