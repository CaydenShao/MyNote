using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNote.Mvc.MvcExtension
{
    /// <summary>
    /// 自定义ValueProviderFactory来创建SessionValueProvider实例。
    /// </summary>
    public class SessionValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new SessionValueProvider();
        }
    }
}