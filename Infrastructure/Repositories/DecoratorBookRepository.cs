using Application.Abstractions.Library;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// This is the repository using GoF: proxy/Decorator pattern to add inmemory caching functionallity dynamically without affecting actual class and violating SOLID principles.
    /// </summary>
    public class DecoratorBookRepository : IBookRepository
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMemoryCache _cache;
        public DecoratorBookRepository(IBookRepository bookRepository, IMemoryCache cache)
        {
            _bookRepository = bookRepository;
            _cache = cache;
        }

        public async Task<Book> Add(Book entity)
        {
            return await _bookRepository.Add(entity);
        }

        public async Task Delete(Book Entity)
        {
             await _bookRepository.Delete(Entity);
        }

        public async Task Update(Book Entity)
        {
            await _bookRepository.Update(Entity);
        }


        //add caching for functions below.

        public async Task<Book> Get(int id)
        {
            string key = $"book-{id}";

            return await _cache.GetOrCreateAsync(
                key,
                 async entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                    return  await _bookRepository.Get(id);
                });
        }


        public async Task<IReadOnlyList<Book>> GetAll()
        {
            string key = "all-books";

            return await _cache.GetOrCreateAsync(
                key,
                async entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                    return await _bookRepository.GetAll();
                });
        }



    }
}
