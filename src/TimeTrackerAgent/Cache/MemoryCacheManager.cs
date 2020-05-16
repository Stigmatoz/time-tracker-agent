using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace TimeTrackerAgent.Cache
{
    public class MemoryCacheManager<T> : IMemoryCacheManager<T>
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();

        public T GetOrCreate(CacheValue type, Func<T> getObj)
        {
            T cacheEntry;
            if (!_cache.TryGetValue(type, out cacheEntry))
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(type, k => new SemaphoreSlim(1, 1));
                mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(type, out cacheEntry))
                    {
                        cacheEntry = getObj();
                        _cache.Set(type, cacheEntry);
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }
            return cacheEntry;
        }

        public void Set(CacheValue type, T obj)
        {
            _cache.Set(type, obj);
        }
    }
}
