using MessoApp.Db.Data;
using MessoApp.Repository.IRepository;
using MessoApp.Repository.Repository;
using MessoApp.Services.IServices;
using MessoApp.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MessoApp.Filters;
// Add the following using if FluentValidation is referenced in your project
using FluentValidation;
using FluentValidation.AspNetCore;
using MessoApp.Validators.RequestValidator;

namespace MessoApp.Helper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessoAppServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MessDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //validation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<MemberProfileRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<MessRequestValidator>();
            services.AddScoped(typeof(FluentValidationFilter<>));

            // Repositories
            services.AddScoped<IMessRepository, MessRepository>();
            services.AddScoped<IMemberProfileRepository, MemberProfileRepository>();

            // Services
            services.AddScoped<IMessService, MessService>();

            services.AddScoped<IMemberProfileService, MemberProfileService>();

            return services;
        }
    }
}
