using MessoApp.Db.Data;
using MessoApp.Repository.IRepository;
using MessoApp.Repository.Repository;
using MessoApp.Services.IServices;
using MessoApp.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessoApp.Helper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessoAppServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<MessDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IMessRepository, MessRepository>();

            // Services
            services.AddScoped<IMessService, MessService>();
            services.AddScoped<IMemberService, MemberService>();

            return services;
        }
    }
}
