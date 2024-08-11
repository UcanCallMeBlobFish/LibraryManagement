using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Email;
using Application.Models.Email;
using Domain.Models;
using Infrastructure.LibraryData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class ReminderService : BackgroundService
{
    private readonly ILogger<ReminderService> _logger;
    private readonly IEmailService _emailService;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ReminderService(
        ILogger<ReminderService> logger,
        IEmailService emailService,
        IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _emailService = emailService;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await CheckForRemindersAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking for reminders.");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Check every minute
        }
    }

    private async Task CheckForRemindersAsync(CancellationToken stoppingToken)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
            var now = DateTime.UtcNow;
            var reminders = await dbContext.Set<Checkout>().Include(a => a.Customer)
                .Where(c => c.ReturnDate.HasValue && c.ReturnDate.Value <= now.AddMinutes(10) && !c.IsReturned)
                .ToListAsync(stoppingToken);

            foreach (var checkout in reminders)
            {
                var emailDto = new EmailDto
                {
                    To = checkout.Customer.Email,
                    Subject = "Reminder: Return Book",
                    Body = $"This is a reminder that the book you borrowed is due to be returned soon. Please return it by {checkout.ReturnDate:MM/dd/yyyy HH:mm}."
                };

                try
                {
                     _emailService.SendEmail(emailDto); // Ensure SendEmailAsync is asynchronous
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to send reminder email to {checkout.Customer.Email}.");
                }
            }
        }
    }
}
