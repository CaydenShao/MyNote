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
    public class NoteCommentContentManager : ManagerBase
    {
        #region Constructors

        public NoteCommentContentManager(string baseAddr) : base(baseAddr)
        { }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<NoteCommentContent> AddNoteCommentContent(AddNoteCommentContentRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddNoteCommentContentRequest> requestValue = new TokenRequest<AddNoteCommentContentRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecommentcontent/AddNoteCommentContent";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddNoteCommentContentRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteCommentContent>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentContentManager", "AddNoteCommentContent", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<NoteCommentContent> GetNoteCommentContentById(GetNoteCommentContentByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteCommentContentByIdRequest> requestValue = new TokenRequest<GetNoteCommentContentByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecommentcontent/GetNoteCommentContentById";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteCommentContentByIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteCommentContent>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentContentManager", "GetNoteCommentContentById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<List<NoteCommentContent>> GetNoteCommentContentsByCommentId(GetNoteCommentContentsByCommentIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteCommentContentsByCommentIdRequest> requestValue = new TokenRequest<GetNoteCommentContentsByCommentIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecommentcontent/GetNoteCommentContentsByCommentId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteCommentContentsByCommentIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<List<NoteCommentContent>>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentContentManager", "GetNoteCommentContentsByCommentId", "HTTP响应失败：" + requestUri);
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

        public async Task<Response<NoteCommentContent>> AddNoteCommentContentAsync(AddNoteCommentContentRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddNoteCommentContentRequest> requestValue = new TokenRequest<AddNoteCommentContentRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecommentcontent/AddNoteCommentContent";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddNoteCommentContentRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteCommentContent>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentContentManager", "AddNoteCommentContentAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<NoteCommentContent>> GetNoteCommentContentByIdAsync(GetNoteCommentContentByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteCommentContentByIdRequest> requestValue = new TokenRequest<GetNoteCommentContentByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecommentcontent/GetNoteCommentContentById";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteCommentContentByIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteCommentContent>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentContentManager", "GetNoteCommentContentById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<List<NoteCommentContent>>> GetNoteCommentContentsByCommentIdAsync(GetNoteCommentContentsByCommentIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteCommentContentsByCommentIdRequest> requestValue = new TokenRequest<GetNoteCommentContentsByCommentIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecommentcontent/GetNoteCommentContentsByCommentId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteCommentContentsByCommentIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<List<NoteCommentContent>>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteCommentContentManager", "GetNoteCommentContentsByCommentIdAsync", "HTTP响应失败：" + requestUri);
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
