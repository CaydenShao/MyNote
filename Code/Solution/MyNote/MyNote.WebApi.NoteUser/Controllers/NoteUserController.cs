using MyNote.Business.Common;
using MyNote.Business.NoteUser.Manager;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.Contracts.DataContracts.NoteUser.Requests;
using MyNote.Contracts.WebApiInterface.NoteUser;
using MyNote.WebApi.Common.ActionFilters;
using MyNote.WebApi.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyNote.WebApi.NoteUser.Controllers
{
    [RoutePrefix("api/noteuser")]
    public class NoteUserController : ApiController , INoteUserServices
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [TokenCheck]
        [Route("GetUserById")]
        [HttpPost]
        public Response<User> GetUserById(TokenRequest<GetUserByIdRequest> request)
        {
            Response<User> response = new Response<User>();

            try
            {
                if (request == null || request.RequestData == null)
                {
                    response.Code = -1;
                    response.Description = "请求参数为空！";
                    response.ResponseData = null;
                }
                else
                {
                    NoteUserManager manager = new NoteUserManager(request.Version);
                    ManagerResult<User> resultUser = manager.GetUserById(request.RequestData.UserId);
                    response.GetResultInfo(resultUser);
                    response.ResponseData = resultUser.ResultData;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                response.Code = -1;
            }

            return response;
        }

        [TokenCheck]
        [Route("GetUserByPhoneNumber")]
        [HttpPost]
        public Response<User> GetUserByAccount(TokenRequest<GetUserByPhoneNumberRequest> request)
        {
            var response = new Response<User>();

            try
            {
                if (request == null || request.RequestData == null)
                {
                    response.Code = -1;
                    response.Description = "请求参数为空！";
                    response.ResponseData = null;
                }
                else
                {
                    NoteUserManager manager = new NoteUserManager(request.Version);
                    ManagerResult<User> resultUser = manager.GetUserByPhoneNumber(request.RequestData.PhoneNumber);
                    response.GetResultInfo(resultUser);
                    response.ResponseData = resultUser.ResultData;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                response.Code = -1;
            }

            return response;
        }

        [TokenCheck]
        [Route("GetUserByToken")]
        [HttpPost]
        public Response<User> GetUserByToken(TokenRequest<GetUserByTokenRequest> request)
        {
            var response = new Response<User>();

            try
            {
                if (request == null || request.RequestData == null)
                {
                    response.Code = -1;
                    response.Description = "请求参数为空！";
                    response.ResponseData = null;
                }
                else
                {
                    NoteUserManager manager = new NoteUserManager(request.Version);
                    ManagerResult<User> resultUser = manager.GetUserByToken(request.RequestData.Token);
                    response.GetResultInfo(resultUser);
                    response.ResponseData = resultUser.ResultData;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                response.Code = -1;
            }

            return response;
        }

        [SignatureCheck]
        [Route("Login")]
        [HttpPost]
        public Response<User> Login(SignedRequest<LoginRequest> request)
        {
            var response = new Response<User>();

            try
            {
                if (request == null || request.RequestData == null)
                {
                    response.Code = -1;
                    response.Description = "请求参数为空！";
                    response.ResponseData = null;
                }
                else
                {
                    NoteUserManager manager = new NoteUserManager(request.Version);
                    ManagerResult<User> result = manager.Login(request.RequestData.Account, request.RequestData.Password);
                    response.GetResultInfo(result);
                    response.ResponseData = result.ResultData;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                response.Code = -1;
            }

            return response;
        }

        [SignatureCheck]
        [Route("Register")]
        [HttpPost]
        public Response<User> Register(SignedRequest<RegisterRequest> request)
        {
            var response = new Response<User>();

            try
            {
                if (request == null || request.RequestData == null)
                {
                    response.Code = -1;
                    response.Description = "请求参数为空！";
                    response.ResponseData = null;
                }
                else
                {
                    NoteUserManager manager = new NoteUserManager(request.Version);
                    ManagerResult<User> result = manager.Register(request.RequestData.User, request.RequestData.PwdHashStr);
                    response.GetResultInfo(result);
                    response.ResponseData = result.ResultData;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                response.Code = -1;
            }

            return response;
        }

        [SignatureCheck]
        [Route("CheckPhoneNumberRegistered")]
        [HttpPost]
        public Response<bool> CheckPhoneNumberRegistered(SignedRequest<CheckPhoneNumberRegisteredRequest> request)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (request == null || request.RequestData == null)
                {
                    response.Code = -1;
                    response.Description = "请求参数为空！";
                    response.ResponseData = false;
                }
                else
                {
                    NoteUserManager manager = new NoteUserManager(request.Version);
                    ManagerResult<bool> result = manager.CheckPhoneNumberRegistered(request.RequestData.PhoneNumber);
                    response.GetResultInfo(result);
                    response.ResponseData = result.ResultData;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                response.Code = -1;
            }

            return response;
        }
    }
}
