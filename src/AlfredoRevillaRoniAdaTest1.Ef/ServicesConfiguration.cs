using System;
using AlfredoRevillaRoniAdaTest1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlfredoRevillaRoniAdaTest1.Ef
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddEfServices(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            services
                .AddScoped<IJobRepository, JobRepository>()
                .AddDbContext<Test1DbContext>(optionsAction)
                ;

            return services;
        }
    }
}