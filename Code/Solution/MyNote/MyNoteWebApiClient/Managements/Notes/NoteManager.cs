using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.Notes.Requests;
using MyNote.Contracts.DataContracts.Notes.Responses;
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
    public class NoteManager : ManagerBase
    {
        #region Constructors

        public NoteManager(string baseAddr) : base(baseAddr)
        { }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<AddNoteAndContentsResponse> AddNoteAddContents(AddNoteAndContentsRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddNoteAndContentsRequest> requestValue = new TokenRequest<AddNoteAndContentsRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/AddNoteAndContents";
                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddNoteAndContentsRequest>>(requestUri, requestValue).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<AddNoteAndContentsResponse>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "AddNoteAddContents", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<Note> GetNoteById(GetNoteByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteByIdRequest> requestValue = new TokenRequest<GetNoteByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/GetNoteById";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteByIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<Note>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "GetNoteById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<List<Note>> GetNotesByAuthorId(GetNotesByAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNotesByAuthorIdRequest> requestValue = new TokenRequest<GetNotesByAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/GetNotesByAuthorId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNotesByAuthorIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<List<Note>>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "GetNotesByAuthorId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<NoteBrowsedRecord> NoteGetBrowsed(NoteGetBrowsedRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<NoteGetBrowsedRequest> requestValue = new TokenRequest<NoteGetBrowsedRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/NoteGetBrowsed";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<NoteGetBrowsedRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteBrowsedRecord>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "NoteGetBrowsed", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SearchNotesResponse> SearchNotesByAuthorId(SearchNotesByAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByAuthorIdRequest> requestValue = new TokenRequest<SearchNotesByAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByAuthorId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByAuthorIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByAuthorId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SearchNotesResponse> SearchNotesByRemark(SearchNotesByKeyStrRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByKeyStrRequest> requestValue = new TokenRequest<SearchNotesByKeyStrRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByRemark";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByKeyStrRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByRemark", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SearchNotesResponse> SearchNotesByRemarkAndAuthorId(SearchNotesByKeyStrAndAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest> requestValue = new TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByRemarkAndAuthorId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByRemarkAndAuthorId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SearchNotesResponse> SearchNotesByTitle(SearchNotesByKeyStrRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByKeyStrRequest> requestValue = new TokenRequest<SearchNotesByKeyStrRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByTitle";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByKeyStrRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByTitle", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SearchNotesResponse> SearchNotesByTitleAndAuthorId(SearchNotesByKeyStrAndAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest> requestValue = new TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByTitleAndAuthorId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByTitleAndAuthorId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SearchNotesResponse> SearchNotesByTimeSpan(SearchNotesByTimeSpanRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByTimeSpanRequest> requestValue = new TokenRequest<SearchNotesByTimeSpanRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByTimeSpan";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByTimeSpanRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByTimeSpan", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SearchNotesResponse> SearchNotesByTimeSpanAndAuthorId(SearchNotesByTimeSpanAndAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByTimeSpanAndAuthorIdRequest> requestValue = new TokenRequest<SearchNotesByTimeSpanAndAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByTimeSpanAndAuthorId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByTimeSpanAndAuthorIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByTimeSpanAndAuthorId", "HTTP响应失败：" + requestUri);
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

        public async Task<Response<AddNoteAndContentsResponse>> AddNoteAddContentsAsync(AddNoteAndContentsRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddNoteAndContentsRequest> requestValue = new TokenRequest<AddNoteAndContentsRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/AddNoteAndContents";
                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddNoteAndContentsRequest>>(requestUri, requestValue);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<AddNoteAndContentsResponse>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "AddNoteAddContents", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<Note>> GetNoteByIdAsync(GetNoteByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteByIdRequest> requestValue = new TokenRequest<GetNoteByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/GetNoteById";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteByIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<Note>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "GetNoteById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<List<Note>>> GetNotesByAuthorIdAsync(GetNotesByAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNotesByAuthorIdRequest> requestValue = new TokenRequest<GetNotesByAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/GetNotesByAuthorId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNotesByAuthorIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<List<Note>>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "GetNotesByAuthorId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<NoteBrowsedRecord>> NoteGetBrowsedAsync(NoteGetBrowsedRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<NoteGetBrowsedRequest> requestValue = new TokenRequest<NoteGetBrowsedRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/NoteGetBrowsed";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<NoteGetBrowsedRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteBrowsedRecord>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "NoteGetBrowsedAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SearchNotesResponse>> SearchNotesByAuthorIdAsync(SearchNotesByAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByAuthorIdRequest> requestValue = new TokenRequest<SearchNotesByAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByAuthorId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByAuthorIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByAuthorId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SearchNotesResponse>> SearchNotesByRemarkAsync(SearchNotesByKeyStrRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByKeyStrRequest> requestValue = new TokenRequest<SearchNotesByKeyStrRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByRemark";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByKeyStrRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByRemark", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SearchNotesResponse>> SearchNotesByRemarkAndAuthorIdAsync(SearchNotesByKeyStrAndAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest> requestValue = new TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByRemarkAndAuthorId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByRemarkAndAuthorId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SearchNotesResponse>> SearchNotesByTitleAsync(SearchNotesByKeyStrRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByKeyStrRequest> requestValue = new TokenRequest<SearchNotesByKeyStrRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByTitle";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByKeyStrRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByTitle", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SearchNotesResponse>> SearchNotesByTitleAndAuthorIdAsync(SearchNotesByKeyStrAndAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest> requestValue = new TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByTitleAndAuthorId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByTitleAndAuthorId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SearchNotesResponse>> SearchNotesByTimeSpanAsync(SearchNotesByTimeSpanRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByTimeSpanRequest> requestValue = new TokenRequest<SearchNotesByTimeSpanRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByTimeSpan";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByTimeSpanRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByTimeSpan", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SearchNotesResponse>> SearchNotesByTimeSpanAndAuthorIdAsync(SearchNotesByTimeSpanAndAuthorIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SearchNotesByTimeSpanAndAuthorIdRequest> requestValue = new TokenRequest<SearchNotesByTimeSpanAndAuthorIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/note/SearchNotesByTimeSpanAndAuthorId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SearchNotesByTimeSpanAndAuthorIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SearchNotesResponse>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteManager", "SearchNotesByTimeSpanAndAuthorIdAsync", "HTTP响应失败：" + requestUri);
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
