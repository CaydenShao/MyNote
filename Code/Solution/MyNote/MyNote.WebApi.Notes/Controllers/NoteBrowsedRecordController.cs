using MyNote.Business.Common;
using MyNote.Business.Notes.Manager;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.Notes.Requests;
using MyNote.Contracts.WebApiInterface.Notes;
using MyNote.WebApi.Common.ActionFilters;
using MyNote.WebApi.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyNote.WebApi.Notes.Controllers
{
    [RoutePrefix("api/notebrowsedrecord")]
    public class NoteBrowsedRecordController : ApiController, INoteBrowsedRecordServices
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [TokenCheck]
        [Route("AddNoteBrowsedRecord")]
        [HttpPost]
        public Response<NoteBrowsedRecord> AddNoteBrowsedRecord(TokenRequest<AddNoteBrowsedRecordRequest> request)
        {
            Response<NoteBrowsedRecord> response = new Response<NoteBrowsedRecord>();

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
                    NoteBrowsedRecordManager manager = new NoteBrowsedRecordManager(request.Version);
                    ManagerResult<NoteBrowsedRecord> result = manager.AddNoteBrowsedRecord(request.RequestData.NoteId, request.RequestData.UserId);
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
        [Route("GetNoteBrowsedRecordsByNoteId")]
        [HttpPost]
        public Response<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByNoteId(TokenRequest<GetNoteBrowsedRecordsByNoteIdRequest> request)
        {
            Response<List<NoteBrowsedRecord>> response = new Response<List<NoteBrowsedRecord>>();

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
                    NoteBrowsedRecordManager manager = new NoteBrowsedRecordManager(request.Version);
                    ManagerResult<List<NoteBrowsedRecord>> result = manager.GetNoteBrowsedRecordsByNoteId(request.RequestData.NoteId);
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
        [Route("GetNoteBrowsedRecordsByUserId")]
        [HttpPost]
        public Response<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByUserId(TokenRequest<GetNoteBrowsedRecordsByUserIdRequest> request)
        {
            Response<List<NoteBrowsedRecord>> response = new Response<List<NoteBrowsedRecord>>();

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
                    NoteBrowsedRecordManager manager = new NoteBrowsedRecordManager(request.Version);
                    ManagerResult<List<NoteBrowsedRecord>> result = manager.GetNoteBrowsedRecordsByNoteId(request.RequestData.UserId);
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
