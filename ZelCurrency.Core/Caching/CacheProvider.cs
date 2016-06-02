//#region References

//using System;
//using System.Collections;
//using System.Web;
//using System.Web.Caching;

//#endregion

//namespace Currency.Caching
//{
//    public class CacheProvider
//    {
//        private const string CONST_cacheKeyPrefix = "CurrencyCache";
//        private readonly System.Web.Caching.Cache currentCache = HttpContext.Current.Cache;

//        public object Get(object key)
//        {
//            return currentCache.Get(CONST_cacheKeyPrefix + key);
//        }

//        public void Put(object key, object value, int expireSeconds)
//        {
//            currentCache.Insert(CONST_cacheKeyPrefix + key,
//                value,
//                null,
//                DateTime.Now.AddSeconds(expireSeconds),
//                System.Web.Caching.Cache.NoSlidingExpiration);
//        }

//        public void Put(object key, object value, string filename)
//        {
//            currentCache.Insert(CONST_cacheKeyPrefix + key, value, new CacheDependency(filename));
//        }

//        public void Remove(object key = null)
//        {
//            currentCache.Remove(CONST_cacheKeyPrefix + key);
//        }

//        public void Clear()
//        {
//            var cacheEnum = currentCache.GetEnumerator();
//            var al = new ArrayList();

//            while (cacheEnum.MoveNext())
//            {
//                al.Add(cacheEnum.Key);
//            }

//            foreach (string key in al)
//            {
//                currentCache.Remove(key);
//            }
//        }
//    }
//}