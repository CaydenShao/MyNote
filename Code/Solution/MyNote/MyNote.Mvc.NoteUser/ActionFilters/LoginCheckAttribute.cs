using MyNote.Business.Common;
using MyNote.Business.NoteUser.Manager;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.NoteUser;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyNote.Mvc.ActionFilters
{
    public class LoginCheckAttribute : FilterAttribute, IAuthorizationFilter
    {
        public const string AuthSaveType_Session = "Session";
        public const string AuthSaveType_Cookie = "Cookie";
        public const string AuthSaveDefualtKey = "Token";
        public const string AuthDefualtUrl = "noteuser/login";
        public const string AuthSaveTypeAppSettingKey = "AuthSaveType";
        public const string AuthSaveKeyAppSettingKey = "AuthSaveKey";
        public const string AuthUrlAppSettingKey = "AuthUrl";
        public const string LoginReturnUrlSaveKey = "LoginReturnUrl";

        /// <summary>
        /// 该值表示登录地址：如：noteuser/login
        /// </summary>
        private static string authUrl = string.Empty;

        /// <summary>
        /// 该值表示yoghurt登录保存登录信息的键名，默认user,在web.Config中设置
        /// </summary>
        private static string authSaveKey = string.Empty;

        /// <summary>
        /// AuthSaveType
        /// </summary>
        private static string authSaveType = string.Empty;

        #region Constructors

        static LoginCheckAttribute()
        {
            string _authSaveType = ConfigurationManager.AppSettings[AuthSaveTypeAppSettingKey];
            string _authUrl = ConfigurationManager.AppSettings[AuthUrlAppSettingKey];
            string _authSaveKey = ConfigurationManager.AppSettings[AuthSaveKeyAppSettingKey];
            authSaveType = string.IsNullOrEmpty(_authSaveType) ? AuthSaveType_Session : _authSaveType;
            authSaveKey = string.IsNullOrEmpty(_authSaveKey) ? AuthSaveDefualtKey : _authSaveKey;
            authUrl = string.IsNullOrEmpty(_authUrl) ? AuthDefualtUrl : _authUrl;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 该值表示登录地址：如：noteuser/login
        /// </summary>
        public static string AuthUrl
        {
            get
            {
                return authUrl;
            }
        }

        /// <summary>
        /// 该值表示yoghurt登录保存登录信息的键名，默认user,在web.Config中设置
        /// </summary>
        public static string AuthSaveKey
        {
            get
            {
                return authSaveKey.Trim();
            }
        }

        /// <summary>
        /// 该值表示用户登录保存登录信息的类型，默认Session,在web.Config中设置
        /// </summary>
        public static string AuthSaveType
        {
            get
            {
                return authSaveType.Trim().ToUpper();
            }
        }

        #endregion

        #region Public methods

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                if (filterContext == null || filterContext.HttpContext == null)
                {
                    throw new Exception("此特性只试用于Web应用程序试用");
                }

                //var flAd = filterContext.ActionDescriptor;
                //var url = string.Format("{0}?Ref=/{1}/{2}", AuthUrl, flAd.ControllerDescriptor.ControllerName,
                //    flAd.ActionName);
                string returnUrl = filterContext.RequestContext.HttpContext.Request.Url.ToString();
                LogHelper.WriteInfo("LoginCheck的url:" + filterContext.RequestContext.HttpContext.Request.Url);

                if (AuthSaveType.Equals(AuthSaveType_Session, StringComparison.OrdinalIgnoreCase))
                {
                    if (filterContext.HttpContext.Session == null)
                    {
                        throw new Exception("服务器Session不可用");
                    }

                    if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) &&
                        !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                            typeof(AllowAnonymousAttribute), true))
                    {
                        if (!CheckToken(filterContext.HttpContext.Session[AuthSaveKey] as string))
                        {
                            //filterContext.Result = new RedirectResult(url);
                            LogHelper.WriteInfo("重定向到登录！");
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "NoteUser", action = "Login", redirectUrl = returnUrl }));
                        }
                    }
                }
                else if (AuthSaveType.Equals(AuthSaveType_Cookie, StringComparison.OrdinalIgnoreCase))
                {
                    if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) &&
                            !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                                typeof(AllowAnonymousAttribute), true))
                    {
                        if (filterContext.HttpContext.Request.Cookies[AuthSaveKey] == null
                            || !CheckToken(filterContext.HttpContext.Request.Cookies[AuthSaveKey].Value))
                        {
                            LogHelper.WriteInfo("重定向到登录！");
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "NoteUser", action = "Login", redirectUrl = returnUrl }));
                        }
                    }
                }
                else
                {
                    throw new ArgumentNullException("用户保存登录信息的方法不能为空，只能为Cookie和Session，请您检查");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }

        public static bool CheckToken(string token)
        {
            NoteUserManager noteUserManager = new NoteUserManager("V2.0");
            ManagerResult<User> result = noteUserManager.GetUserByToken(token);

            if (result.Code == 0 && result.ResultData != null)
            {
                LogHelper.WriteInfo("Token验证成功：" + token);
                return true;
            }
            else
            {
                LogHelper.WriteInfo("Token验证失败：" + token);
                return false;
            }
        }

        public static void SetToken(Controller controller, string token)
        {
            if (AuthSaveType.Equals(AuthSaveType_Cookie, StringComparison.OrdinalIgnoreCase))
            {
                if (controller.Response.Cookies[LoginCheckAttribute.AuthSaveKey] == null)
                {
                    HttpCookie httpCookie = new HttpCookie(LoginCheckAttribute.AuthSaveKey, token);
                    controller.Response.Cookies.Add(httpCookie);
                    LogHelper.WriteInfo("token添加成功cookie1！");
                }
                else
                {
                    controller.Response.Cookies[LoginCheckAttribute.AuthSaveKey].Value = token;
                    LogHelper.WriteInfo("token添加成功cookie2！");
                }
            }
            else
            {
                controller.Session[LoginCheckAttribute.AuthSaveKey] = token;
                LogHelper.WriteInfo("token添加成功session！");
            }

            LogHelper.WriteInfo("token添加完成！");
        }

        public static string GetToken(Controller controller)
        {
            if (LoginCheckAttribute.AuthSaveType == LoginCheckAttribute.AuthSaveType_Cookie)
            {
                if (controller.Response.Cookies[LoginCheckAttribute.AuthSaveKey] == null)
                {
                    return controller.Response.Cookies[LoginCheckAttribute.AuthSaveKey].Value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return controller.Session[LoginCheckAttribute.AuthSaveKey] as string;
            }
        }

        #endregion
    }
}