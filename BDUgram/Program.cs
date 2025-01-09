
using BDUgram.BL;
using BDUgram.DAL;
using BDUgram.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<BdugramDbContext>(
                opt =>
                {
                    opt.UseSqlServer(
                        builder.Configuration.GetConnectionString("MSSql"));
                });
            builder.Services.AddAuth(builder.Configuration);
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
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
