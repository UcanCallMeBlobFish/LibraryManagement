using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using Infrastructure;
using Application;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configure NLog
LogManager.LoadConfiguration("NLog.config");

builder.Logging.ClearProviders(); // Remove other logging providers
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); // Set minimum log level
builder.Logging.AddNLog(); // Add NLog as the logging provider

// Add services to the container
builder.Services.ConfigureApplicationServices();
builder.Services.AddPersistenceService(builder.Configuration);
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
app.UseAuthorization();
app.MapControllers();

app.Run();
