using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
using MyNote.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MyNote.WebApi.Common.ActionFilters
{
    /// <summary>
    /// 验证公共接口调用信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class PublicCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                bool hasAccessed = false;

                if (actionContext.ActionArguments == null || actionContext.ActionArguments.Count != 1)
                {
                    hasAccessed = false;
                }
                else
                {
                    PublicRequired required = actionContext.ActionArguments.Values.First() as PublicRequired;

                    if (required == null)
                    {
                        hasAccessed = false;
                    }
                    else
                    {
                        hasAccessed = true;
                    }
                }

                if (!hasAccessed)
                {
                    // 在action执行前终止请求时，应该使用填充方法Response，将不返回action方法体。 
                    actionContext.Response = actionContext.Request.CreateResponse<Response<object>>(new Response<object>
                    {
                        Code = -1,
                        HasAccessed = false
                    });
                }

                base.OnActionExecuting(actionContext);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
