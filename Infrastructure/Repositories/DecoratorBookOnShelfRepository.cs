using Application.Abstractions.Caching;
using Application.Abstractions.Library;
using Domain.Models;
using Infrastructure.Services.CachingServices.Redis;
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

        private readonly ICacheService _cacheService;
        public DecoratorBookOnShelfRepository(IBookOnShelfRepository bookOnShelfRepository, IDistributedCache distributedCache, ICacheService cacheService)
        {
            _cacheService = cacheService;
            _bookOnShelfRepository = bookOnShelfRepository;
            _distributedCache = distributedCache;
        }

        public async Task<BookOnShelves> Add(BookOnShelves entity)
        {
            string key = $"BookOnShelves-{entity.Id}";
            await _bookOnShelfRepository.Add(entity);
            await _cacheService.SetAsync(key, entity, cancellationToken: default);
            await _cacheService.RemoveAsync("AllBookOnShelves");
            return await _bookOnShelfRepository.Get(entity.Id);
        }

        public async Task Delete(BookOnShelves Entity)
        {
            string key = $"BookOnShelves-{Entity.Id}";
            await _bookOnShelfRepository.Delete(Entity);
            await _cacheService.RemoveAsync(key, cancellationToken: default);

        }
        public async Task Update(BookOnShelves Entity)
        {
            string key = $"BookOnShelves-{Entity.Id}";

            await _bookOnShelfRepository.Update(Entity);

            await _cacheService.RemoveAsync(key, cancellationToken: default);
            await _cacheService.RemoveAsync("AllBookOnShelves");

            var updatedEntity = await _bookOnShelfRepository.Get(Entity.Id);
            await _cacheService.SetAsync(key, updatedEntity, cancellationToken: default);
        }

        // Using Redis D Caching for functions provided below.
        //public async Task<BookOnShelves> Get(int id)
        //{
        //    string key = $"BookOnShelves-{id}";

        //    string? cachedMember = await _distributedCache.GetStringAsync(key);

        //    BookOnShelves? book;
        //    //there is no such a thing in a redis, so lets return and store too.
        //    if (string.IsNullOrEmpty(cachedMember)) 
        //    {
        //        var cacheOptions = new DistributedCacheEntryOptions
        //        {
        //            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
        //        };
        //        book = await _bookOnShelfRepository.Get(id);
        //        await _distributedCache.SetStringAsync(key,JsonConvert.SerializeObject(book), cacheOptions);

        //        return book;
        //    } 

        //    //if found then deserialize and return.
        //    book = JsonConvert.DeserializeObject<BookOnShelves>(cachedMember);
        //    return book;

        //}

        public async Task<BookOnShelves> Get(int id)
        {
            string key = $"BookOnShelves-{id}";

            BookOnShelves? book = await _cacheService.GetAsync<BookOnShelves>(key);

            if (book == null)
            {
                book = await _bookOnShelfRepository.Get(id);
                await _cacheService.SetAsync(key, book, cancellationToken: default); // Set cache with a default TTL if needed
            }

            return book;
        }
        public async Task<IReadOnlyList<BookOnShelves>> GetAll()
        {
            string key = "AllBookOnShelves";

            IReadOnlyList<BookOnShelves>? books = await _cacheService.GetAsync<IReadOnlyList<BookOnShelves>>(key);

            if (books == null)
            {
                books = await _bookOnShelfRepository.GetAll();
                await _cacheService.SetAsync(key, books, cancellationToken: default); // Set cache with a default TTL if needed
            }

            return books;
        }


    }
}
