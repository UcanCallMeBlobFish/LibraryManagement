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
    public class CheckOutRepository : GenericRepository<Checkout>, ICheckOutRepository
    {
        public CheckOutRepository(LibraryDbContext context) : base(context)
        {
        }

       
    }
}
