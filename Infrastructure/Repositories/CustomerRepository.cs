using Application.Abstractions;
using Domain.Models;
using Infrastructure.LibraryData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, IGenericRepository<Customer>
    {
        public CustomerRepository(LibraryDbContext context) : base(context)
        {
        }

        public override Task<Customer> Get(int id)
        {
            return base.Get(id);
        }

        public async Task<Customer> Get(string id)
        {
            return await _context.Set<Customer>().Where(a => a.Username == id).FirstOrDefaultAsync();
        }
    }
}
