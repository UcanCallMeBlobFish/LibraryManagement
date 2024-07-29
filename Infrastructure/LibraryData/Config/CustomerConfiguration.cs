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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Username);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.LastName)
                .IsRequired();

            builder.Property(c => c.Email)
                .IsRequired();

            builder.Property(c => c.Status)
                .IsRequired();

            builder.HasMany(a => a.Checkouts)
                .WithOne(c => c.Customer)
                .HasForeignKey(f => f.CustomerId);

            builder.HasMany(a => a.Alerts)
                .WithOne(c => c.User)
                .HasForeignKey(f => f.UserTo);


        }
    }
}
