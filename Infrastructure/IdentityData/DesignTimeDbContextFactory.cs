using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IdentityData
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
    {
        public IdentityDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();

            var connectionString = configuration.GetConnectionString("IdentityDatabase");

            optionsBuilder.UseSqlServer(connectionString);

            return new IdentityDbContext(optionsBuilder.Options);
        }
    }

}
