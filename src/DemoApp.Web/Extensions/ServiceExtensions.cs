using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DemoApp.Infrastructure.Data;
using DemoApp.Core.Interfaces;
using DemoApp.Core.Services;
using DemoApp.Infrastructure.Logging;
using DemoApp.Infrastructure.Services;

namespace DemoApp.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AutoEmailDbContext>(c =>
            c.UseSqlServer(config.GetConnectionString("DemoConnection")));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IAppEmailService, AppEmailService>();
        }

        public static void ConfigureInfraServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}
