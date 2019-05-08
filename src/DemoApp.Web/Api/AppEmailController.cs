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
        public async Task<IActionResult> Lists()
        {

            var catalogModel = await _appEmailService.GetEmailLists();

            return Ok(catalogModel);
        }

        [HttpPost]
        public async Task<ActionResult<AppEmail>> PostAppEmail(AppEmail appEmail)
        {
            //_appEmailService.(appEmail);
            await _appEmailService.SaveAsync();

            return CreatedAtAction("GetAppEmail", new { id = appEmail.App_id }, appEmail);
        }

        // GET: api/ToDoItems
        [HttpGet]
        public IActionResult List()
        {

            var catalogModel = _appEmailService.GetEmailList();

            return Ok(catalogModel);
        }

    }
}