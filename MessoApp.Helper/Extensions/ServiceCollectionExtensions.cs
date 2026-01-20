using MessoApp.Db.Data;
using MessoApp.Repositories;
using MessoApp.Repository.IRepository;
using MessoApp.Repository.Repository;
using MessoApp.Services.IServices;
using MessoApp.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddScoped<IMemberRepository, MemberRepository>();

            // Services
            services.AddScoped<IMessService, MessService>();
            services.AddScoped<IMemberService, MemberService>();

            return services;
        }
    }
}
