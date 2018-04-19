using MyNote.Business.Common;
using MyNote.Business.Common.Manager;
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
    /// 验证签名
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SignatureCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                bool hasAccessed = false;
                string description = "签名验证不予通过！";

                if (actionContext.ActionArguments == null || actionContext.ActionArguments.Count != 1)
                {
                    hasAccessed = false;
                    description = "签名验证参数为空！";
                }
                else
                {
                    SignatureRequired required = actionContext.ActionArguments.Values.First() as SignatureRequired;

                    if (required == null)
                    {
                        hasAccessed = false;
                        description = "签名验证参数不符合规范！";
                    }
                    else
                    {
                        SecurityCheckManager securityCheckManager = new SecurityCheckManager(required.Version);
                        ManagerResult<bool> checkResult = securityCheckManager.CheckSignature(required.Signature,
                            required.TimeStamp, required.Nonce, required.AppId);
                        hasAccessed = checkResult.ResultData;

                        if (!hasAccessed)
                        {
                            description = "签名验证不予通过！";
                        }
                    }
                }

                if (!hasAccessed)
                {
                    // 在action执行前终止请求时，应该使用填充方法Response，将不返回action方法体。 
                    actionContext.Response = actionContext.Request.CreateResponse<Response<object>>(new Response<object>
                    {
                        Code = -1,
                        HasAccessed = false,
                        Description = description
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
