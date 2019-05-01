using System.Threading.Tasks;

namespace DemoApp.Core.Interfaces
{

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}