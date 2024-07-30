﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using System.Reflection;

namespace Application
{
    public static class Dependency
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // Register AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register logging
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders(); // Remove all other logging providers
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); // Set the minimum log level
                loggingBuilder.AddNLog(); // Add NLog as the logging provider
            });

            // Configure NLog
            LogManager.LoadConfiguration("NLog.config");

            return services;
        }
    }
}
