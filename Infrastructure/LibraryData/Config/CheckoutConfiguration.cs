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
    public class CheckoutConfiguration : IEntityTypeConfiguration<Checkout>
    {
        public void Configure(EntityTypeBuilder<Checkout> builder)
        {
            builder.HasKey(c => c.CheckoutId);

            builder.HasIndex(a => a.CustomerId);

            builder.HasIndex(a => a.CheckoutId);

            builder.Property(c => c.CustomerId)
                .IsRequired();

            builder.Property(c => c.CheckoutDate)
                .IsRequired();

            builder.Property(c => c.ReturnDate)
                .IsRequired();


            builder.HasOne(c => c.BookOnShelves)
                .WithMany(bos => bos.Checkouts)
                .HasForeignKey(c => c.BookOnShelvesId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Customer)
                .WithMany(c => c.Checkouts)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
