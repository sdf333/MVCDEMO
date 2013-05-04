using System;
using System.Web.Caching;

namespace SDF.Core.Caching
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class CacheExtensions
    {
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get<T>(cacheManager, key, acquire, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire, DateTime absoluteExpiration, TimeSpan slidingExpiration) 
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                if (result == null)
                {
                    return default(T);
                }
                cacheManager.Set(key, result, absoluteExpiration, slidingExpiration);
                return result; 
            }
        }
    }
}
