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
    public class NoteContentManager : ManagerBase
    {
        #region Constructors

        public NoteContentManager(string baseAddr) : base(baseAddr)
        { }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<List<NoteContent>> GetNoteContentByNoteId(GetNoteContentsByNoteIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteContentsByNoteIdRequest> requestValue = new TokenRequest<GetNoteContentsByNoteIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecontent/GetNoteContentByNoteId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteContentsByNoteIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<List<NoteContent>>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteContentManager", "GetNoteContentByNoteId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<NoteContent> GetNoteContentsById(GetNoteContentByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteContentByIdRequest> requestValue = new TokenRequest<GetNoteContentByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecontent/GetNoteContentsById";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteContentByIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteContent>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteContentManager", "GetNoteContentsById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<NoteContent> AddContent(AddContentRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddContentRequest> requestValue = new TokenRequest<AddContentRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecontent/AddContent";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddContentRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteContent>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteContentManager", "AddContent", "HTTP响应失败：" + requestUri);
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

        public async Task<Response<List<NoteContent>>> GetNoteContentByNoteIdAsync(GetNoteContentsByNoteIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteContentsByNoteIdRequest> requestValue = new TokenRequest<GetNoteContentsByNoteIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecontent/GetNoteContentByNoteId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteContentsByNoteIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<List<NoteContent>>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteContentManager", "GetNoteContentByNoteIdAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<NoteContent>> GetNoteContentsByIdAsync(GetNoteContentByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteContentByIdRequest> requestValue = new TokenRequest<GetNoteContentByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecontent/GetNoteContentsById";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteContentByIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteContent>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteContentManager", "GetNoteContentsByIdAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<NoteContent>> AddContentAsync(AddContentRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddContentRequest> requestValue = new TokenRequest<AddContentRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notecontent/AddContent";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddContentRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteContent>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteContentManager", "AddContentAsync", "HTTP响应失败：" + requestUri);
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
