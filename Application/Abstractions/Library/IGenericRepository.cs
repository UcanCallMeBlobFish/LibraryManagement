using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Library
{
    public interface IGenericRepository<T>
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();

        Task<T> Add(T entity);
        Task Update(T Entity);

        Task Delete(T Entity);


    }
}
