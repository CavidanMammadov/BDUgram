using BDUgram.BL.Services.implements;
using BDUgram.BL.Services.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices( this  IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
