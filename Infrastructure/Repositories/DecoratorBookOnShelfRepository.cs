using Application.Abstractions.Library;
using Domain.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DecoratorBookOnShelfRepository : IBookOnShelfRepository
    {
        private readonly IBookOnShelfRepository _bookOnShelfRepository;
        private readonly IDistributedCache _distributedCache;

        public DecoratorBookOnShelfRepository(IBookOnShelfRepository bookOnShelfRepository, IDistributedCache distributedCache)
        {
            _bookOnShelfRepository = bookOnShelfRepository;
            _distributedCache = distributedCache;
        }

        public async Task<BookOnShelves> Add(BookOnShelves entity)
        {
           return await _bookOnShelfRepository.Add(entity);
        }

        public async Task Delete(BookOnShelves Entity)
        {
            await _bookOnShelfRepository.Delete(Entity);
        }
        public async Task Update(BookOnShelves Entity)
        {
            await _bookOnShelfRepository.Update(Entity);
        }

        // Using Redis D Caching for functions provided below.
        public async Task<BookOnShelves> Get(int id)
        {
            string key = $"BookOnShelves-{id}";

            string? cachedMember = await _distributedCache.GetStringAsync(key);

            BookOnShelves? book;
            //there is no such a thing in a redis, so lets return and store too.
            if (string.IsNullOrEmpty(cachedMember)) 
            {
                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                };
                book = await _bookOnShelfRepository.Get(id);
                await _distributedCache.SetStringAsync(key,JsonConvert.SerializeObject(book), cacheOptions);

                return book;
            } 

            //if found then deserialize and return.
            book = JsonConvert.DeserializeObject<BookOnShelves>(cachedMember);
            return book;

        }

        public async Task<IReadOnlyList<BookOnShelves>> GetAll()
        {
            string key = "AllBookOnShelves";

            string? cachedMember = await _distributedCache.GetStringAsync(key);

            IReadOnlyList<BookOnShelves>? book;
            //there is no such a thing in a redis, so lets return and store too.
            if (string.IsNullOrEmpty(cachedMember))
            {
                book = await _bookOnShelfRepository.GetAll();
                await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(book));

                return book;
            }

            //if found then deserialize and return.
            book = JsonConvert.DeserializeObject<IReadOnlyList<BookOnShelves>>(cachedMember);
            return book;
        }

        
    }
}
