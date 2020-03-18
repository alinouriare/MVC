using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.Infrastructures
{
    public interface ICacheProvider
    {
        void Set(string key, string value);

        string Get(string key);
    }


    public class InMemory : ICacheProvider
    {
        private readonly IMemoryCache memoryCache;

        public InMemory(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public string Get(string key)
        {
            return memoryCache.Get(key).ToString();
        }

        public void Set(string key, string value)
        {
            memoryCache.Set(key, value);
        }
    }

    public class DistributedCache : ICacheProvider
    {
        private readonly IDistributedCache distributed;

        public DistributedCache(IDistributedCache distributed)
        {
            this.distributed = distributed;
        }
        public string Get(string key)
        {
            return distributed.GetString(key);
        }

        public void Set(string key, string value)
        {
            distributed.SetString(key, value);
        }
    }
}
