﻿using BDugram.Core.Repositories;
using BDUgram.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.DAL
{
    public static  class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
