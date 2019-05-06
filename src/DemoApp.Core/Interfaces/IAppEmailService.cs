using System.Threading.Tasks;

namespace DemoApp.Core.Interfaces
{
    public interface IAppEmailService
    {
         Task GetEmail(int appid);
    }
}