using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Library
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> Get(string id);

    }
}
