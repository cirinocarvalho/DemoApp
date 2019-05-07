using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApp.Core.Entities;
using DemoApp.Infrastructure.Data;

namespace DemoApp.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppEmails2Controller : ControllerBase
    {
        private readonly AutoEmailDbContext _context;

        public AppEmails2Controller(AutoEmailDbContext context)
        {
            _context = context;
        }

        // GET: api/AppEmails2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppEmail>>> GetAppEmail()
        {
            return await _context.AppEmail.ToListAsync();
        }

        // GET: api/AppEmails2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppEmail>> GetAppEmail(int id)
        {
            var appEmail = await _context.AppEmail.FindAsync(id);

            if (appEmail == null)
            {
                return NotFound();
            }

            return appEmail;
        }

        // PUT: api/AppEmails2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppEmail(int id, AppEmail appEmail)
        {
            if (id != appEmail.App_id)
            {
                return BadRequest();
            }

            _context.Entry(appEmail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppEmailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AppEmails2
        [HttpPost]
        public async Task<ActionResult<AppEmail>> PostAppEmail(AppEmail appEmail)
        {
            _context.AppEmail.Add(appEmail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppEmail", new { id = appEmail.App_id }, appEmail);
        }

        // DELETE: api/AppEmails2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppEmail>> DeleteAppEmail(int id)
        {
            var appEmail = await _context.AppEmail.FindAsync(id);
            if (appEmail == null)
            {
                return NotFound();
            }

            _context.AppEmail.Remove(appEmail);
            await _context.SaveChangesAsync();

            return appEmail;
        }

        private bool AppEmailExists(int id)
        {
            return _context.AppEmail.Any(e => e.App_id == id);
        }
    }
}
