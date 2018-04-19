using MyNote.Business.Common;
using MyNote.Business.Notes.Manager;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.Notes.Requests;
using MyNote.Contracts.DataContracts.Notes.Responses;
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
    [RoutePrefix("api/note")]
    public class NoteController : ApiController, INoteServices
    {
        [HttpOptions]
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }

        [TokenCheck]
        [Route("AddNote")]
        [HttpPost]
        public Response<Note> AddNote(TokenRequest<AddNoteRequest> request)
        {
            Response<Note> response = new Response<Note>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    ManagerResult<Note> result = manager.AddNote(request.RequestData.Note);
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
        [Route("AddNoteAndContents")]
        [HttpPost]
        public Response<AddNoteAndContentsResponse> AddNoteAndContents(TokenRequest<AddNoteAndContentsRequest> request)
        {
            Response<AddNoteAndContentsResponse> response = new Response<AddNoteAndContentsResponse>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    ManagerResult<bool> result = manager.AddNoteAndContents(request.RequestData.Note, request.RequestData.NoteContents);
                    response.GetResultInfo(result);

                    if (result.ResultData)
                    {
                        response.ResponseData = new AddNoteAndContentsResponse()
                        {
                            Note = request.RequestData.Note,
                            NoteContents = request.RequestData.NoteContents
                        };
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

        [TokenCheck]
        [Route("GetNoteById")]
        [HttpPost]
        public Response<Note> GetNoteById(TokenRequest<GetNoteByIdRequest> request)
        {
            Response<Note> response = new Response<Note>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    ManagerResult<Note> result = manager.GetNoteById(request.RequestData.Id);
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
        [Route("GetNotesByAuthorId")]
        [HttpPost]
        public Response<List<Note>> GetNotesByAuthorId(TokenRequest<GetNotesByAuthorIdRequest> request)
        {
            Response<List<Note>> response = new Response<List<Note>>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    ManagerResult<List<Note>> result = manager.GetNotesByAuthorId(request.RequestData.AuthorId);
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
        [Route("NoteGetBrowsed")]
        [HttpPost]
        public Response<NoteBrowsedRecord> NoteGetBrowsed(TokenRequest<NoteGetBrowsedRequest> request)
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
                    DateTime lastBrowsedTime = DateTime.Now;
                    NoteManager manager = new NoteManager(request.Version);
                    ManagerResult<NoteBrowsedRecord> result = manager.NoteGetBrowsed(request.RequestData.NoteId, request.RequestData.UserId);
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
        [Route("SearchNotesByAuthorId")]
        [HttpPost]
        public Response<SearchNotesResponse> SearchNotesByAuthorId(TokenRequest<SearchNotesByAuthorIdRequest> request)
        {
            Response<SearchNotesResponse> response = new Response<SearchNotesResponse>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    int totalRows = 0;
                    ManagerResult<List<Note>> result = manager.SearchNotesByAuthorId(request.RequestData.PageSize, request.RequestData.PageIndex, request.RequestData.AuthorId, out totalRows);
                    response.GetResultInfo(result);
                    response.ResponseData = new SearchNotesResponse()
                    {
                        Notes = result.ResultData,
                        TotalRows = totalRows
                    };
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
        [Route("SearchNotesByRemark")]
        [HttpPost]
        public Response<SearchNotesResponse> SearchNotesByRemark(TokenRequest<SearchNotesByKeyStrRequest> request)
        {
            Response<SearchNotesResponse> response = new Response<SearchNotesResponse>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    int totalRows = 0;
                    ManagerResult<List<Note>> result = manager.SearchNotesByRemark(request.RequestData.PageSize, request.RequestData.PageIndex, request.RequestData.KeyStr, out totalRows);
                    response.GetResultInfo(result);
                    response.ResponseData = new SearchNotesResponse()
                    {
                        Notes = result.ResultData,
                        TotalRows = totalRows
                    };
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
        [Route("SearchNotesByRemarkAndAuthorId")]
        [HttpPost]
        public Response<SearchNotesResponse> SearchNotesByRemarkAndAuthorId(TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest> request)
        {
            Response<SearchNotesResponse> response = new Response<SearchNotesResponse>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    int totalRows = 0;
                    ManagerResult<List<Note>> result = manager.SearchNotesByRemarkAndAuthorId(request.RequestData.PageSize, request.RequestData.PageIndex, request.RequestData.KeyStr, request.RequestData.AuthorId, out totalRows);
                    response.GetResultInfo(result);
                    response.ResponseData = new SearchNotesResponse()
                    {
                        Notes = result.ResultData,
                        TotalRows = totalRows
                    };
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
        [Route("SearchNotesByTitle")]
        [HttpPost]
        public Response<SearchNotesResponse> SearchNotesByTitle(TokenRequest<SearchNotesByKeyStrRequest> request)
        {
            Response<SearchNotesResponse> response = new Response<SearchNotesResponse>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    int totalRows = 0;
                    ManagerResult<List<Note>> result = manager.SearchNotesByTitle(request.RequestData.PageSize, request.RequestData.PageIndex, request.RequestData.KeyStr, out totalRows);
                    response.GetResultInfo(result);
                    response.ResponseData = new SearchNotesResponse()
                    {
                        Notes = result.ResultData,
                        TotalRows = totalRows
                    };
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
        [Route("SearchNotesByTitleAndAuthorId")]
        [HttpPost]
        public Response<SearchNotesResponse> SearchNotesByTitleAndAuthorId(TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest> request)
        {
            Response<SearchNotesResponse> response = new Response<SearchNotesResponse>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    int totalRows = 0;
                    ManagerResult<List<Note>> result = manager.SearchNotesByTitleAndAuthorId(request.RequestData.PageSize, request.RequestData.PageIndex, request.RequestData.KeyStr, request.RequestData.AuthorId, out totalRows);
                    response.GetResultInfo(result);
                    response.ResponseData = new SearchNotesResponse()
                    {
                        Notes = result.ResultData,
                        TotalRows = totalRows
                    };
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
        [Route("SearchNotesByTimeSpan")]
        [HttpPost]
        public Response<SearchNotesResponse> SearchNotesByTimeSpan(TokenRequest<SearchNotesByTimeSpanRequest> request)
        {
            Response<SearchNotesResponse> response = new Response<SearchNotesResponse>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    int totalRows = 0;
                    ManagerResult<List<Note>> result = manager.SearchNotesByTimeSpan(request.RequestData.PageSize, request.RequestData.PageIndex, request.RequestData.StartTime, request.RequestData.EndTime, out totalRows);
                    response.GetResultInfo(result);
                    response.ResponseData = new SearchNotesResponse()
                    {
                        Notes = result.ResultData,
                        TotalRows = totalRows
                    };
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
        [Route("SearchNotesByTimeSpanAndAuthorId")]
        [HttpPost]
        public Response<SearchNotesResponse> SearchNotesByTimeSpanAndAuthorId(TokenRequest<SearchNotesByTimeSpanAndAuthorIdRequest> request)
        {
            Response<SearchNotesResponse> response = new Response<SearchNotesResponse>();

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
                    NoteManager manager = new NoteManager(request.Version);
                    int totalRows = 0;
                    ManagerResult<List<Note>> result = manager.SearchNotesByTimeSpanAndAuthorId(request.RequestData.PageSize, request.RequestData.PageIndex, request.RequestData.StartTime, request.RequestData.EndTime, request.RequestData.AuthorId, out totalRows);
                    response.GetResultInfo(result);
                    response.ResponseData = new SearchNotesResponse()
                    {
                        Notes = result.ResultData,
                        TotalRows = totalRows
                    };
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
