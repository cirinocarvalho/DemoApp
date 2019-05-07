using System.Threading.Tasks;
using System.Collections.Generic;
using DemoApp.Core.Entities;

namespace DemoApp.Core.Interfaces
{
    public interface IAppEmailService
    {
         IEnumerable<AppEmail> GetEmailList();
    }
}