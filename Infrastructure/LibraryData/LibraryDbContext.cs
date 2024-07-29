using Domain.Models;
using Infrastructure.LibraryData.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.LibraryData
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookOnShelves> BookOnShelves { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new EditorConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookOnShelvesConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CheckoutConfiguration());
            modelBuilder.ApplyConfiguration(new AlertConfiguration());
        }
    }
}
