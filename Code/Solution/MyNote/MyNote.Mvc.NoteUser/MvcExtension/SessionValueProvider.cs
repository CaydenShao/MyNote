using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNote.Mvc.MvcExtension
{
    /// <summary>
    /// 把一些数据放到Session中，返回ValueProviderResult类型，自定义的SessionValueProvider会把这个ValueProviderResult交给ModelBinder，从而，可以让我们在action方法参数中，可以直接使用Session保存的类型。
    /// </summary>
    public class SessionValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return HttpContext.Current.Session[prefix] != null;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                return null;
            }

            return new ValueProviderResult(
                HttpContext.Current.Session[key],
                HttpContext.Current.Session[key].ToString(),
                CultureInfo.CurrentCulture);
        }
    }
}