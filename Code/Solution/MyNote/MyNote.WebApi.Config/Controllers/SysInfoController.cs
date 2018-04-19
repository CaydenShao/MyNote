using MyNote.Business.Common;
using MyNote.Business.Config.Manager;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Config;
using MyNote.Contracts.DataContracts.Config.Requests;
using MyNote.Contracts.WebApiInterface.Config;
using MyNote.WebApi.Common.ActionFilters;
using MyNote.WebApi.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyNote.WebApi.Config.Controllers
{
    [RoutePrefix("api/sysinfo")]
    public class SysInfoController : ApiController, ISysInfoServices
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [PublicCheck]
        [Route("GetServerDateTime")]
        [HttpPost]
        public Response<DateTime> GetServerDateTime(PublicRequest<object> request)
        {
            return new Response<DateTime>()
            {
                ResponseData = DateTime.Now
            };
        }

        [PublicCheck]
        [Route("GetSysInfoById")]
        [HttpPost]
        public Response<SysInfo> GetSysInfoById(PublicRequest<GetSysInfoByIdRequest> request)
        {
            Response<SysInfo> response = new Response<SysInfo>();

            try
            {
                if (request == null || request.RequestData == null)
                {
                    response.Code = -1;
                    response.Description = "参数为空！";
                    response.ResponseData = null;
                }
                else
                {
                    SysInfoManager manager = new SysInfoManager(request.Version);
                    ManagerResult<SysInfo> result = manager.GetSysInfoById(request.RequestData.Id);
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

        [PublicCheck]
        [Route("GetSysInfoByName")]
        [HttpPost]
        public Response<SysInfo> GetSysInfoByName(PublicRequest<GetSysInfoByNameRequest> request)
        {
            Response<SysInfo> response = new Response<SysInfo>();

            try
            {
                if (request == null || request.RequestData == null)
                {
                    response.Code = -1;
                    response.Description = "参数为空！";
                    response.ResponseData = null;
                }
                else
                {
                    SysInfoManager manager = new SysInfoManager(request.Version);
                    ManagerResult<SysInfo> result = manager.GetSysInfoByName(request.RequestData.Name);
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

        [TokenCheck]
        [Route("AddSysInfo")]
        [HttpPost]
        public Response<SysInfo> AddSysInfo(TokenRequest<SysInfo> request)
        {
            Response<SysInfo> response = new Response<SysInfo>();

            try
            {
                if (request == null || request.RequestData == null)
                {
                    response.Code = -1;
                    response.Description = "参数为空！";
                    response.ResponseData = null;
                }
                else
                {
                    SysInfoManager manager = new SysInfoManager(request.Version);
                    ManagerResult<SysInfo> result = manager.AddSysInfo(request.RequestData);
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
