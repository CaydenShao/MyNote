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
    [RoutePrefix("api/notecomment")]
    public class NoteCommentController : ApiController, INoteCommentServices
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [TokenCheck]
        [Route("AddNoteComment")]
        [HttpPost]
        [HttpPut]
        public Response<NoteComment> AddNoteComment(TokenRequest<AddNoteCommentRequest> request)
        {
            Response<NoteComment> response = new Response<NoteComment>();

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
                    NoteCommentManager manager = new NoteCommentManager(request.Version);
                    ManagerResult<NoteComment> result = manager.AddNoteComment(request.RequestData.NoteComment);
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
        [Route("GetNoteCommentById")]
        [HttpPost]
        public Response<NoteComment> GetNoteCommentById(TokenRequest<GetNoteCommentByIdRequest> request)
        {
            Response<NoteComment> response = new Response<NoteComment>();

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
                    NoteCommentManager manager = new NoteCommentManager(request.Version);
                    ManagerResult<NoteComment> result = manager.GetNoteCommentById(request.RequestData.Id);
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
        [Compression]
        [Route("GetNoteCommentsByNoteId")]
        [HttpPost]
        public Response<List<NoteComment>> GetNoteCommentsByNoteId(TokenRequest<GetNoteCommentsByNoteIdRequest> request)
        {
            Response<List<NoteComment>> response = new Response<List<NoteComment>>();

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
                    NoteCommentManager manager = new NoteCommentManager(request.Version);
                    ManagerResult<List<NoteComment>> result = manager.GetNoteCommentsByNoteId(request.RequestData.NoteId);
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
