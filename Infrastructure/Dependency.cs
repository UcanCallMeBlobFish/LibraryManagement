using Application.Abstractions;
using Infrastructure.LibraryData;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Dependency
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            



            services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LibraryDatabase")));


            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAlertRepository, AlertRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookOnShelfRepository, BookOnShelfRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICheckOutRepository, CheckOutRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEditorRepository, EditorRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
