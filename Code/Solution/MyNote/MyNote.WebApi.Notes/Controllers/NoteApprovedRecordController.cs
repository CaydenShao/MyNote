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
    [RoutePrefix("api/noteapprovedrecord")]
    public class NoteApprovedRecordController : ApiController, INoteApprovedRecordServices
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [TokenCheck]
        [HttpPost]
        [Route("ApproveNote")]
        public Response<NoteApprovedRecord> ApproveNote(TokenRequest<ApproveNoteRequest> request)
        {
            Response<NoteApprovedRecord> response = new Response<NoteApprovedRecord>();

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
                    NoteApprovedRecordManager manager = new NoteApprovedRecordManager(request.Version);
                    ManagerResult<NoteApprovedRecord> result = manager.NoteGetApproved(request.RequestData.NoteId, request.RequestData.UserId);
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
        [HttpPost]
        [Route("GetNoteApprovedRecordsByUserId")]
        public Response<List<NoteApprovedRecord>> GetNoteApprovedRecordsByUserId(TokenRequest<GetNoteApprovedRecordsByUserIdRequest> request)
        {
            Response<List<NoteApprovedRecord>> response = new Response<List<NoteApprovedRecord>>();

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
                    NoteApprovedRecordManager manager = new NoteApprovedRecordManager(request.Version);
                    ManagerResult<List<NoteApprovedRecord>> result = manager.GetNoteApprovedRecordsByUserId(request.RequestData.UserId);
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
        [HttpPost]
        [Route("GetNoteApprovedRecordsByNoteId")]
        public Response<List<NoteApprovedRecord>> GetNoteApprovedRecordsByNoteId(TokenRequest<GetNoteApprovedRecordsByNoteIdRequest> request)
        {
            Response<List<NoteApprovedRecord>> response = new Response<List<NoteApprovedRecord>>();

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
                    NoteApprovedRecordManager manager = new NoteApprovedRecordManager(request.Version);
                    ManagerResult<List<NoteApprovedRecord>> result = manager.GetNoteApprovedRecordsByNoteId(request.RequestData.NoteId);
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
        [HttpPost]
        [Route("GetNoteApprovedRecordByNoteIdAndUserId")]
        public Response<NoteApprovedRecord> GetNoteApprovedRecordsByNoteIdAndUserId(TokenRequest<GetNoteApprovedRecordsByNoteIdAndUserIdRequest> request)
        {
            Response<NoteApprovedRecord> response = new Response<NoteApprovedRecord>();

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
                    NoteApprovedRecordManager manager = new NoteApprovedRecordManager(request.Version);
                    ManagerResult<NoteApprovedRecord> result = manager.GetNoteApprovedRecordByNoteIdAndUserId(request.RequestData.NoteId, request.RequestData.UserId);
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
