using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.LibraryData.Config
{
    public class AlertConfiguration : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.UserTo).IsRequired();

            builder.HasIndex(a => a.UserTo);

            builder.Property(a => a.Subject).IsRequired();

            builder.Property(a => a.Text).IsRequired().HasMaxLength(100);

            builder.HasOne<Customer>()
                .WithMany(a => a.Alerts)
                .HasForeignKey(a => a.UserTo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
