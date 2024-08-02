using Application.Abstractions.Library;
using Domain.Models;
using Infrastructure.LibraryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AlertRepository : GenericRepository<Alert>, IAlertRepository
    {
        public AlertRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
