﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace MyNote.WebApi.Common.Helpers
{
    /// <summary>
    /// 缓存辅助类 
    /// </summary>
    public class CacheHelper
    {
        //在类库中使用Caching,或者HttpRuntime都需要添加System.Web引用   
        //private static System.Web.Caching.Cache Cache = System.Web.HttpContext.Current.Cache;  

        //也可以用下面这句代码代替上面这句代码  
        private static Cache Cache = HttpRuntime.Cache;
        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        /// <param name="key">键</param>  
        /// <param name="val">值</param>  
        /// <returns></returns>  
        public static object SetCache(string key, object val)
        {
            if (Cache[key] == null)
            {
                Cache.Insert(key, val, null, DateTime.Now.AddDays(1), TimeSpan.Zero);
            }

            return Cache[key];
        }  
        
        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        /// <param name="key">键</param>  
        /// <param name="val">值</param>  
        /// <param name="minute">缓存的时间长度（单位:分钟）</param>  
        /// <returns></returns>  
        public static object SetCache(string key, object val, double minute)
        {
            if (Cache[key] == null)
            {
                Cache.Insert(key, val, null, DateTime.Now.AddMinutes(minute), TimeSpan.Zero);
            }

            return Cache[key];
        }  
        
        /// <summary>  
        ///  获取数据缓存  
        /// </summary>  
        /// <param name="key">键</param>  
        /// <returns></returns>  
        public static object GetCache(string key)
        {
            return Cache[key];
        }  
        
        /// <summary>  
        /// 移除指定数据缓存  
        /// </summary>  
        /// <param name="key">要移除缓存的键</param>  
        public static void RemoveCache(string key)
        {
            if (Cache[key] != null)
            {
                Cache.Remove(key);
            }
        }

        /// <summary>  
        /// 移除全部缓存  
        /// </summary>  
        public static void RemoveAllCache()
        {
            //Cache.GetEnumerator()方法是检索用于循环访问包含在缓存中的键设置及其值的字典枚举数。  
            IDictionaryEnumerator CacheEnum = Cache.GetEnumerator();

            // MoveNext()方法是将枚举数推进到集合的下一个元素。  
            while (CacheEnum.MoveNext())
            {
                Cache.Remove(CacheEnum.Key.ToString());
            }
        }  

    }
}
