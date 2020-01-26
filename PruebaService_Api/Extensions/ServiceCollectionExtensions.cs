using Microsoft.Extensions.Configuration;
using PruebaService_Api.Middleware;
using PruebaService_App.Contracts;
using PruebaService_App.Contracts.HttpClients;
using PruebaService_App.Services;
using PruebaService_App.Services.HttpClients;
using PruebaService_Common.Configurations;
using PruebaService_Data.Contracts;
using PruebaService_Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIoC(this IServiceCollection services) =>
            services
                .AddTransient<IPeople, PeopleService>()
                .AddTransient<IPersonData, PersonDataService>();

        public static IServiceCollection AddCustomMiddleware(this IServiceCollection services) =>
            services
                .AddTransient<ErrorMiddleware>();

        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration config)
        {
            var pruebaApiServiceBase = config.GetSection($"{nameof(PruebaEndpointConfig)}:Base").Get<Uri>();

            services
                .AddHttpClient<IPruebaHttpClient, PruebaHttpClientService>(client => client.BaseAddress = pruebaApiServiceBase);

            return services;
        }            

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration config) =>
            services
                .AddConfiguration<PruebaEndpointConfig>(config);

        public static IServiceCollection AddConfiguration<T>(this IServiceCollection services, IConfiguration config) where T : class
        {
            var configuration = config.GetSection(typeof(T).Name).Get<T>();

            if (!(configuration is null))
            {
                services.AddSingleton(configuration);
            }

            return services;
        }
    }
}
