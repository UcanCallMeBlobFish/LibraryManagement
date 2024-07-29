using Application.Abstractions;
using Domain.Models;
using Infrastructure.LibraryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EditorRepository : GenericRepository<Editor>, IEditorRepository
    {
        public EditorRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
