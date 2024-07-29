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
    public class EditorConfiguration : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> builder)
        {
            builder.HasKey(e => e.EditorId);

            builder.Property(e => e.EditorName)
                .IsRequired();

            builder.HasMany(a => a.bookOnShelves)
                .WithOne(p => p.Editor)
                .HasForeignKey(k => k.EditorId);
        
        }
    }
}
