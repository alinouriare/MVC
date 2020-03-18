//using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.Extensions.Caching.Memory;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace StateManagement.Infrastructures
//{
//    public interface ICacheProviderG<T>
//    {
//        void Set(string key, string value);

//        string Get(string key);
//    }

//    public class InMemoryG<te> : ICacheProviderG<T>
//    {
//        private readonly IMemoryCache memory;

//        public InMemoryG(IMemoryCache memory)
//        {
//            this.memory = memory;
//        }
//        public string Get(string key)
//        {

//            return memory.Get(key).ToString();
//        }

//        public void Set(string key, string value)
//        {
//            memory.Set(key, value);
//        }
//    }

//    public class DistributedCacheG<IDistributedCache> : ICacheProviderG<IDistributedCache>
//    {
//        private readonly IDistributedCache distributed;

//        public DistributedCacheG(IDistributedCache distributed)
//        {
//            this.distributed = distributed;
//        }
//        public string Get(string key)
//        {

//            return distributed.GetString(key);
//        }

//        public void Set(string key, string value)
//        {
//            distributed.SetString(key, value);
//        }
//    }
//}
