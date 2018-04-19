using MyNote.Business.Common;
using MyNote.Business.NoteUser.Manager;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
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
    [RoutePrefix("api/verification")]
    public class VerificationController : ApiController, IVerificationService
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [SignatureCheck]
        [Route("GetVerificationById")]
        [HttpPost]
        public Response<Verification> GetVerificationById(SignedRequest<GetVerificationByIdRequest> request)
        {
            Response<Verification> response = new Response<Verification>();

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
                    VerificationManager verificationManager = new VerificationManager(request.Version);
                    ManagerResult<Verification> result = verificationManager.GetVerificationById(request.RequestData.Id);
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
        [Route("GetVerificationByPhoneNumber")]
        [HttpPost]
        public Response<Verification> GetVerificationByPhoneNumber(SignedRequest<GetVerificationByPhoneNumberRequest> request)
        {
            Response<Verification> response = new Response<Verification>();

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
                    VerificationManager verificationManager = new VerificationManager(request.Version);
                    ManagerResult<Verification> result = verificationManager.GetVerificationByPhoneNumber(request.RequestData.PhoneNumber);
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
        [Route("AddVerification")]
        [HttpPost]
        public Response<Verification> AddVerification(SignedRequest<Verification> request)
        {
            Response<Verification> response = new Response<Verification>();

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
                    VerificationManager verificationManager = new VerificationManager(request.Version);
                    ManagerResult<Verification> result = verificationManager.AddVerification(request.RequestData);
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
        [Route("GenerateVerification")]
        [HttpPost]
        public Response<bool> GenerateVerification(SignedRequest<GenerateVerificationRequest> request)
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
                    VerificationManager verificationManager = new VerificationManager(request.Version);
                    ManagerResult<Verification> result = verificationManager.GenerateVerification(request.RequestData.PhoneNumber);
                    response.GetResultInfo(result);

                    if (result.ResultData != null)
                    {
                        response.ResponseData = true;
                    }
                    else
                    {
                        response.ResponseData = false;
                    }
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
        [Route("CheckVerification")]
        [HttpPost]
        public Response<bool> CheckVerification(SignedRequest<CheckVerificationRequest> request)
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
                    VerificationManager verificationManager = new VerificationManager(request.Version);
                    ManagerResult<bool> result = verificationManager.CheckVerification(request.RequestData.PhoneNumber, request.RequestData.Code);
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
