
using BDUgram.BL;
using BDUgram.DAL;
using BDUgram.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BDUgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme   
                    {
                    Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    }
                    },
                    Array.Empty<string>()
                    }
                    });
                });
            builder.Services.AddDbContext<BdugramDbContext>(
                opt =>
                {
                    opt.UseSqlServer(
                        builder.Configuration.GetConnectionString("MSSql"));
                });
            builder.Services.AddAuth(builder.Configuration);
            builder.Services.AddJwtOptions(builder.Configuration);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddFluentValidation();
            builder.Services.AddMapper();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opt =>
                {
                    opt.EnablePersistAuthorization();
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
