using Application.Abstractions.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.CachingServices.Redis
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private static readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(5); // TTL of 5 minutes

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            string? cachedValue = await _distributedCache.GetStringAsync(key, cancellationToken);

            if (cachedValue == null)
                return null;

            T? value = JsonConvert.DeserializeObject<T>(cachedValue);

            return value;
        }


        public async Task RemoveAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {

            await _distributedCache.RemoveAsync
                (key, cancellationToken);
        }

        public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
        {
            string cacheValue = JsonConvert.SerializeObject(value);

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = DefaultExpiration // Set TTL to 5 minutes
            };
            await _distributedCache.SetStringAsync(key, cacheValue, cacheOptions, cancellationToken);
        }

       
    }
}
