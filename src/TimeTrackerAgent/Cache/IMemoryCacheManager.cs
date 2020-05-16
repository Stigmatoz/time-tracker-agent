using System;

namespace TimeTrackerAgent.Cache
{
    public interface IMemoryCacheManager<T>
    {
        T GetOrCreate(CacheValue type, Func<T> getObj);
        void Set(CacheValue type, T obj);
    }
}