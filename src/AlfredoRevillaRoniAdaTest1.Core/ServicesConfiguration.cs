using System;
using System.Collections.Generic;
using AlfredoRevillaRoniAdaTest1.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AlfredoRevillaRoniAdaTest1
{
    public static class ServicesConfiguration
    {
        private static readonly List<Action<IMapperConfigurationExpression>> mapperConfigurationExpressions = new List<Action<IMapperConfigurationExpression>>();

        private static MapperConfiguration CreateMapperConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                foreach (var item in mapperConfigurationExpressions)
                {
                    item(c);
                }
            });
        }

        public static IServiceCollection AddMappingExpression(this IServiceCollection services, Action<IMapperConfigurationExpression> mappingExpression)
        {
            mapperConfigurationExpressions.Add(mappingExpression);
            return services;
        }

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services
                .AddScoped<IJobService, JobService>()
                .AddSingleton<IMapper>(sp => new Mapper(CreateMapperConfiguration()))
                .AddMappingExpression(JobService.MappingExpression)
                ;

            return services;
        }
    }
}