using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;

namespace Application
{
    public static class Dependency
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // Scan the assembly for classes that inherit from Profile and register them
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
