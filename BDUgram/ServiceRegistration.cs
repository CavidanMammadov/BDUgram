
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BDUgram.BL.DTOs.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace BDUgram
{
    public static class ServiceRegistration
    {
    

        public static IServiceCollection AddJwt(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                var SecKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!));
                x.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience =configuration["Jwt:Audience"],
                    IssuerSigningKey = SecKey
                };

            });
            return services;

        }
    }
}


