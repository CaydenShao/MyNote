using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.Notes.Requests;
using MyNoteWebApiClient.Bases;
using MyNoteWebApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteWebApiClient.Managements.Notes
{
    public class NoteCommentManager : ManagerBase
    {
        #region Constructors

        public NoteCommentManager(string baseAddr) : base(baseAddr)
        {

        }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<NoteComment> AddNoteComment(AddNoteCommentRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddNoteCommentRequest> requestValue = new TokenRequest<AddNoteCommentRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecomment/AddNoteComment";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddNoteCommentRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteComment>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentManager", "AddNoteComment", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<NoteComment> GetNoteCommentById(GetNoteCommentByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteCommentByIdRequest> requestValue = new TokenRequest<GetNoteCommentByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecomment/GetNoteCommentById";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteCommentByIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteComment>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentManager", "GetNoteCommentById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<List<NoteComment>> GetNoteCommentsByNoteId(GetNoteCommentsByNoteIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteCommentsByNoteIdRequest> requestValue = new TokenRequest<GetNoteCommentsByNoteIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecomment/GetNoteCommentsByNoteId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteCommentsByNoteIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<List<NoteComment>>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentManager", "GetNoteCommentsByNoteId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        #endregion

        #region Async methods

        public async Task<Response<NoteComment>> AddNoteCommentAsync(AddNoteCommentRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddNoteCommentRequest> requestValue = new TokenRequest<AddNoteCommentRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecomment/AddNoteComment";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddNoteCommentRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteComment>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentManager", "AddNoteCommentAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<NoteComment>> GetNoteCommentByIdAsync(GetNoteCommentByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteCommentByIdRequest> requestValue = new TokenRequest<GetNoteCommentByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecomment/GetNoteCommentById";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteCommentByIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteComment>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentManager", "GetNoteCommentById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<List<NoteComment>>> GetNoteCommentsByNoteIdAsync(GetNoteCommentsByNoteIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteCommentsByNoteIdRequest> requestValue = new TokenRequest<GetNoteCommentsByNoteIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecomment/GetNoteCommentsByNoteId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteCommentsByNoteIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<List<NoteComment>>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentManager", "GetNoteCommentsByNoteIdAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        #endregion

        #endregion
    }
}
