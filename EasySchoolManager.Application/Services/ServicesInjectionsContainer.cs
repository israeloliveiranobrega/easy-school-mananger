using EasySchoolManager.Api.Services.Implementations.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.Extensions.Configuration;
using EasySchoolManager.Api.Services.Interfaces;
using EasySchoolManager.Api.Services.Implementations;

namespace EasySchoolManager.Application.Services
{
    public static class ServicesInjectionsContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUserServices, UserServices>();

            return services;
        }
    }
}
