using DemoApp.Core.Interfaces;
using DemoApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.Core.Services
{
    public class AppEmailService : IAppEmailService
    {
        private readonly IAsyncRepository<AppEmail> _appEmailRepository;
        private readonly IAppLogger<AppEmailService> _logger;

        public AppEmailService(IAsyncRepository<AppEmail> appEmailRepository,
           IAppLogger<AppEmailService> logger)
        {
            _appEmailRepository = appEmailRepository;
            _logger = logger;
        }

        public async Task GetEmail (int appid)
        {
            var email = await _appEmailRepository.GetByIdAsync(appid);
        }

    }
}