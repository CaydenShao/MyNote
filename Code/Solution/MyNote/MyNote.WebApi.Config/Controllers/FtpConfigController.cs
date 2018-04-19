using MyNote.Business.Common;
using MyNote.Business.Common.Manager;
using MyNote.Business.Config.Manager;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
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
    [RoutePrefix("api/ftpconfig")]
    public class FtpConfigController : ApiController, IFtpConfigServices
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [TokenCheck]
        [Route("AddFtpConfig")]
        [HttpPost]
        public Response<FtpConfig> AddFtpConfig(TokenRequest<FtpConfig> request)
        {
            Response<FtpConfig> response = new Response<FtpConfig>();

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
                    FtpConfigManager manager = new FtpConfigManager(request.Version);
                    ManagerResult<FtpConfig> result = manager.AddFtpConfig(request.RequestData);
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
        [Route("GetFtpConfigById")]
        [HttpPost]
        public Response<FtpConfig> GetFtpConfigById(TokenRequest<GetFtpConfigByIdRequest> request)
        {
            Response<FtpConfig> response = new Response<FtpConfig>();

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
                    FtpConfigManager manager = new FtpConfigManager(request.Version);
                    ManagerResult<FtpConfig> result = manager.GetFtpConfigById(request.RequestData.Id);
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
        [Route("GetFtpConfigByName")]
        [HttpPost]
        public Response<FtpConfig> GetFtpConfigByName(TokenRequest<GetFtpConfigByNameRequest> request)
        {
            Response<FtpConfig> response = new Response<FtpConfig>();

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
                    FtpConfigManager manager = new FtpConfigManager(request.Version);
                    ManagerResult<FtpConfig> result = manager.GetFtpConfigByName(request.RequestData.Name);
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
