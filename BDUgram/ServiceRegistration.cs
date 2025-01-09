
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BDUgram.BL.DTOs.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace BDUgram
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<BL.DTOs.Options.JwtOptions>(Configuration.GetSection(BL.DTOs.Options.JwtOptions.Jwt));
            return services;
        }



        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration Configuration)
        {
            JwtOptions JwtOpt = new JwtOptions();
            JwtOpt.Issuer = Configuration.GetSection("JwtOptions")["Issuer"]!;
            JwtOpt.Audience = Configuration.GetSection("JwtOptions")["Audience"]!;
            JwtOpt.SecretKey = Configuration.GetSection("JwtOptions")["SecretKey"]!;
            var SignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOpt.SecretKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = SignInKey,
                        ValidAudience = JwtOpt.Audience,
                        ValidIssuer = JwtOpt.Issuer,
                        ClockSkew = TimeSpan.Zero,
                    };

                });
            return services;
        }
    }
}


