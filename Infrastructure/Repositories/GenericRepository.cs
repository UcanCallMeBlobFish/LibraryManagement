using Application.Abstractions.Library;
using Infrastructure.LibraryData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly LibraryDbContext _context;

        public GenericRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public  async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
        }

        public virtual async Task<T> Get(int id)
        {

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Update(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;


        }
    }
}
