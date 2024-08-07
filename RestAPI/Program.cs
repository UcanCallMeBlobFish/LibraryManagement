using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Infrastructure;
using Application;
using MediatR;
using RestAPI;
using RestAPI.Middleware;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.Console()
    .WriteTo.File(@"C:\Users\Kiu-Student\Desktop\LibraryManagement\Application\Logs\app-log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog(); // Use Serilog for logging

// Clear default providers and set Serilog as the logging provider
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

// Add services to the container
builder.Services.ConfigureApplicationServices();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddSwaggerDoc();

///builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
