// Add the following using if FluentValidation is referenced in your project
using FluentValidation;
using FluentValidation.AspNetCore;
using MessoApp.Db.Data;
using MessoApp.Filters;
using MessoApp.Repository.IRepository;
using MessoApp.Repository.Repository;
using MessoApp.Services.IServices;
using MessoApp.Services.Services;
using MessoApp.Validators.RequestValidator;
using Microsoft.EntityFrameworkCore;

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
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IMessRepository, MessRepository>();
            services.AddScoped<IMemberProfileRepository, MemberProfileRepository>();
            services.AddScoped<IMemberMessDetailRepository, MemberMessDetailRepository>();

            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IMessService, MessService>();
            services.AddScoped<IMemberProfileService, MemberProfileService>();
            services.AddScoped<IMemberMessDetailService, MemberMessDetailService>();

            return services;
        }
    }
}
