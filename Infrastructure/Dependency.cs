﻿using Application.Abstractions.Caching;
using Application.Abstractions.Email;
using Application.Abstractions.Identity;
using Application.Abstractions.Library;
using Application.Models.Identity.JWTModels;
using Domain.Models;
using Infrastructure.IdentityData;
using Infrastructure.IdentityData.Models;
using Infrastructure.LibraryData;
using Infrastructure.Repositories;
using Infrastructure.Services.CachingServices.Redis;
using Infrastructure.Services.Email;
using Infrastructure.Services.IdentityServices;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            //Background service
            services.AddHostedService<ReminderService>();


            //inmem
            services.AddMemoryCache();

            //reddis distributed
            services.AddStackExchangeRedisCache(redisOptions =>
            {
                string connection = configuration.GetConnectionString("redis");

                redisOptions.Configuration = "localhost:6379";

            });

            //configure library db
            services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LibraryDatabase")));


            //configure identity db
            services.AddDbContext<IdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("IdentityDatabase")));
          
            //add identityservice and custom user.
            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

            //login,register service.
            services.AddTransient<IAuthService, AuthService>();


            //this is for IOptions in authservice.cs, mapping json obj to cs obj.
            services.Configure<JWTSettings>(configuration.GetSection("JwtSettings"));

            


            // add jwt Bearer as default authentication, so our API will be protected by bearer by default.
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(o =>
               {
                   //fetch validation items from json file, comparison check happens in middleware,pipelines by .net.
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.Zero,
                       ValidIssuer = configuration["JwtSettings:Issuer"],
                       ValidAudience = configuration["JwtSettings:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                   };
               });


            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IAlertRepository, AlertRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();


            //InMem Caching
            services.AddScoped<IBookRepository, BookRepository>();
            services.Decorate<IBookRepository, DecoratorBookRepository>();

            //Redis Distributed Caching
            services.AddScoped<IBookOnShelfRepository, BookOnShelfRepository>();
            services.Decorate<IBookOnShelfRepository, DecoratorBookOnShelfRepository>();
            services.AddScoped<ICacheService, CacheService>();


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICheckOutRepository, CheckOutRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEditorRepository, EditorRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IEmailService, EmailService>();

            return services;
        }
    }
}
