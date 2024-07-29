using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IAlertRepository Alerts { get; }
        IAuthorRepository Authors { get; }
        IBookAuthorRepository BookAuthors { get; }
        IBookOnShelfRepository BookOnShelves { get; }
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }
        ICheckOutRepository CheckOuts { get; }
        ICustomerRepository Customers { get; }
        IEditorRepository Editors { get; }
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> SaveAsync();
    }

}
