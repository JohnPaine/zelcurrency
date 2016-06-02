//#region References

//using System;
//using System.IO;

//#endregion

//namespace Currency.Caching
//{
//    public static class CacheHelper
//    {
//        private const int CONST_cacheExpireSeconds = 300;

//        public static T Get<T>(string filename, Func<string, T> func)
//        {
//            var result = (T) new CacheProvider().Get(filename);

//            if (result == null)
//            {
//                result = func(filename);
//                Put(filename, result);
//            }

//            return result;
//        }

//        public static T Get<T>(object key, Func<T> func)
//        {
//            var result = (T) new CacheProvider().Get(key);

//            if (result == null)
//            {
//                result = func();

//                if (result != null)
//                {
//                    Put(key, result);
//                }
//            }

//            return result;
//        }

//        private static void Put<T>(object key, T result)
//        {
//            new CacheProvider().Put(key, result, CONST_cacheExpireSeconds);
//        }

//        private static void Put<T>(string filename, T result)
//        {
//            if (!File.Exists(filename))
//            {
//                File.Create(filename);
//            }

//            new CacheProvider().Put(filename, result, filename);
//        }

//        public static void Remove(object key)
//        {
//            new CacheProvider().Remove(key);
//        }

//        public static void Clear()
//        {
//            new CacheProvider().Clear();
//        }
//    }
//}