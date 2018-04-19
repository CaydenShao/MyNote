using MyNote.Business.Common;
using MyNote.Business.NoteUser.Manager;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.Mvc.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyNote.Mvc.Controllers.NoteUser
{
    [RoutePrefix("noteuser")]
    public class NoteUserController : Controller
    {
        [LoginCheck]
        [Route("User/{id}")]
        public ActionResult User(int id)
        {
            NoteUserManager noteUserManager = new NoteUserManager("V2.0");
            return View("~/Views/NoteUser/User/User.cshtml", noteUserManager.GetUserById(id));
        }

        [Route("login/{redirectUrl}")]
        public ActionResult Login(string redirectUrl)
        {
            return View("~/Views/NoteUser/User/Login.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("login/{redirectUrl}")]
        public ActionResult Login(string redirectUrl, string phoneNumber, string password)
        {
            NoteUserManager noteUserManager = new NoteUserManager("V2.0");
            ManagerResult<User> result = noteUserManager.Login(phoneNumber, password);

            if (result.Code == 0 && result.ResultData != null)
            {
                LoginCheckAttribute.SetToken(this, result.ResultData.Token);
                LogHelper.WriteInfo("登录成功！");

                if (!string.IsNullOrEmpty(redirectUrl))
                {
                    LogHelper.WriteInfo("loginReturnUrl:" + redirectUrl);
                    return Redirect(redirectUrl);
                }
                else
                {
                    LogHelper.WriteInfo("loginReturnUrl为空！");
                }
            }

            return Redirect("~/Views/Home/About.cshtml");
        }
    }
}