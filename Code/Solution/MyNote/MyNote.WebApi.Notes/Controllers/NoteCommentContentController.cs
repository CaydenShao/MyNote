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
    [RoutePrefix("api/notecommentcontent")]
    public class NoteCommentContentController : ApiController, INoteCommentContentServices
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [TokenCheck]
        [Compression]
        [Route("AddNoteCommentContent")]
        [HttpPost]
        [HttpPut]
        public Response<NoteCommentContent> AddNoteCommentContent(TokenRequest<AddNoteCommentContentRequest> request)
        {
            Response<NoteCommentContent> response = new Response<NoteCommentContent>();

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
                    NoteCommentContentManager manager = new NoteCommentContentManager(request.Version);
                    ManagerResult<NoteCommentContent> result = manager.AddNoteCommentContent(request.RequestData.NoteCommentContent);
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
        [Route("GetNoteCommentContentById")]
        [HttpPost]
        public Response<NoteCommentContent> GetNoteCommentContentById(TokenRequest<GetNoteCommentContentByIdRequest> request)
        {
            Response<NoteCommentContent> response = new Response<NoteCommentContent>();

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
                    NoteCommentContentManager manager = new NoteCommentContentManager(request.Version);
                    ManagerResult<NoteCommentContent> result = manager.GetNoteCommentContentById(request.RequestData.Id);
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
        [Route("GetNoteCommentContentsByCommentId")]
        [HttpPost]
        public Response<List<NoteCommentContent>> GetNoteCommentContentsByCommentId(TokenRequest<GetNoteCommentContentsByCommentIdRequest> request)
        {
            Response<List<NoteCommentContent>> response = new Response<List<NoteCommentContent>>();

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
                    NoteCommentContentManager manager = new NoteCommentContentManager(request.Version);
                    ManagerResult<List<NoteCommentContent>> result = manager.GetNoteCommentContentsByCommentId(request.RequestData.CommentId);
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
