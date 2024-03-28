using Contracts;
using Microsoft.Extensions.DependencyInjection;
using Service.Contracts;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace LoggerService
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options =>
        { 
            options.AddPolicy("CorsPolicy", builder => 
            builder.AllowAnyOrigin().
            WithExposedHeaders("X-Pagination").
            AllowAnyMethod().
            AllowAnyHeader()); 
        });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureResponseCaching(this IServiceCollection services)=>
            services.AddResponseCaching();
    } 

}
