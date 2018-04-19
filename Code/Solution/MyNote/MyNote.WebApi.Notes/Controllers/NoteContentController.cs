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
    [RoutePrefix("api/notecontent")]
    public class NoteContentController : ApiController, INoteContentServices
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [TokenCheck]
        [Compression]
        [Route("GetNoteContentByNoteId")]
        [HttpPost]
        public Response<List<NoteContent>> GetNoteContentsByNoteId(TokenRequest<GetNoteContentsByNoteIdRequest> request)
        {
            Response<List<NoteContent>> response = new Response<List<NoteContent>>();

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
                    NoteContentManager manager = new NoteContentManager(request.Version);
                    ManagerResult<List<NoteContent>> result = manager.GetNoteContentsByNoteId(request.RequestData.NoteId);
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
        [Route("GetNoteContentsById")]
        [HttpPost]
        public Response<NoteContent> GetNoteContentsById(TokenRequest<GetNoteContentByIdRequest> request)
        {
            Response<NoteContent> response = new Response<NoteContent>();

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
                    NoteContentManager manager = new NoteContentManager(request.Version);
                    ManagerResult<NoteContent> result = manager.GetNoteContentById(request.RequestData.Id);
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
        [Route("AddContent")]
        [HttpPost]
        [HttpPut]
        public Response<NoteContent> AddContent(TokenRequest<AddContentRequest> request)
        {
            Response<NoteContent> response = new Response<NoteContent>();

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
                    NoteContentManager manager = new NoteContentManager(request.Version);
                    ManagerResult<NoteContent> result = manager.AddContent(request.RequestData.NoteContent);
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
