using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.LibraryData.Config
{
    public class BookOnShelvesConfiguration : IEntityTypeConfiguration<BookOnShelves>
    {
        public void Configure(EntityTypeBuilder<BookOnShelves> builder)
        {

            builder.HasKey(a => a.Id);

            builder.Property(a => a.UserNote).HasMaxLength(100);

            builder.HasOne(a => a.Book).WithMany(c => c.bookOnShelves).HasForeignKey(a => a.BookId);

            builder.HasOne(a => a.Editor).WithMany(c => c.bookOnShelves).HasForeignKey(a => a.EditorId);

            builder.HasMany(check => check.Checkouts).WithOne(a => a.BookOnShelves).HasForeignKey(a => a.BookOnShelvesId);
        }
    }
}
