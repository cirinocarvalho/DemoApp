using DemoApp.Core.Interfaces;
using DemoApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.Core.Services
{
    public class AppEmailService : IAppEmailService
    {
        //private readonly IRepository<AppEmail> _appEmailRepository;
        private IRepositoryWrapper _repoWrapper;
        private readonly IAppLogger<AppEmailService> _logger;

        public AppEmailService(IRepositoryWrapper repoWrappery,
           IAppLogger<AppEmailService> logger)
        {
            _repoWrapper = repoWrappery;
            _logger = logger;
        }

        public async Task<IEnumerable<AppEmail>> GetEmailLists()
        {
            var listEmail = await _repoWrapper.Owner.GetAllAsync();

            return listEmail;
        }

        public IEnumerable<AppEmail> GetEmailList()
        {
            var listEmail = _repoWrapper.Owner.GetAll();

            return listEmail;
        }

        public void Save()
        {
            _repoWrapper.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _repoWrapper.SaveChangesAsync();
        }
    }
}