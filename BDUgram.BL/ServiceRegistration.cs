using BDUgram.BL.Services.implements;
using BDUgram.BL.Services.interfaces;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Identity.Client;
using BDUgram.BL.ExternalSerives.Implements;
using BDUgram.BL.ExternalSerives.Abstracts;


namespace BDUgram.BL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices( this  IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IBlogService, BlogService>();



            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            return services;
        }
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
           services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(typeof(ServiceRegistration));
            return services;
              
        }
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistration));
            return services;
        }
    }
}
