using DemoApp.Core.Entities;
using DemoApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Web.Api
{
    public class AppEmailController : BaseApiController
    {
        private readonly IAppEmailService _appEmailService;

        public AppEmailController(IAppEmailService appEmailService)
        {
            _appEmailService = appEmailService;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IActionResult> List()
        {
           
            var catalogModel = await _appEmailService.GetEmailList();
            
            return Ok(catalogModel);
        }
    }
}