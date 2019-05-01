using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DemoApp.Core.Entities;

namespace DemoApp.Infrastructure.Data
{
    public class AutoEmailDbContext : DbContext
    {
        public AutoEmailDbContext(DbContextOptions<AutoEmailDbContext> options) : base(options)
        {

        }

        public DbSet<AppEmail> AppEmail { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
