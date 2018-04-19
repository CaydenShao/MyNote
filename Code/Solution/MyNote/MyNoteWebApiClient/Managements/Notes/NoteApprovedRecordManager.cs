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
    public class NoteApprovedRecordManager : ManagerBase
    {
        #region Constructors

        public NoteApprovedRecordManager(string baseAddr) : base(baseAddr)
        { }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<NoteApprovedRecord> ApproveNote(ApproveNoteRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<ApproveNoteRequest> requestValue = new TokenRequest<ApproveNoteRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteapprovedrecord/ApproveNote";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<ApproveNoteRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteApprovedRecord>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteApprovedRecordManager", "ApproveNote", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<List<NoteApprovedRecord>> GetNoteApprovedRecordsByUserId(GetNoteApprovedRecordsByUserIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteApprovedRecordsByUserIdRequest> requestValue = new TokenRequest<GetNoteApprovedRecordsByUserIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteapprovedrecord/GetNoteApprovedRecordsByUserId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteApprovedRecordsByUserIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<List<NoteApprovedRecord>>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteApprovedRecordManager", "GetNoteApprovedRecordsByUserId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<List<NoteApprovedRecord>> GetNoteApprovedRecordsByNoteId(GetNoteApprovedRecordsByNoteIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteApprovedRecordsByNoteIdRequest> requestValue = new TokenRequest<GetNoteApprovedRecordsByNoteIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteapprovedrecord/GetNoteApprovedRecordsByNoteId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteApprovedRecordsByNoteIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<List<NoteApprovedRecord>>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteApprovedRecordManager", "GetNoteApprovedRecordsByNoteId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<NoteApprovedRecord> GetNoteApprovedRecordByNoteIdAndUserId(GetNoteApprovedRecordsByNoteIdAndUserIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteApprovedRecordsByNoteIdAndUserIdRequest> requestValue = new TokenRequest<GetNoteApprovedRecordsByNoteIdAndUserIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteapprovedrecord/GetNoteApprovedRecordByNoteIdAndUserId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteApprovedRecordsByNoteIdAndUserIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteApprovedRecord>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteApprovedRecordManager", "GetNoteApprovedRecordByNoteIdAndUserId", "HTTP响应失败：" + requestUri);
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

        public async Task<Response<NoteApprovedRecord>> ApproveNoteAsync(ApproveNoteRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<ApproveNoteRequest> requestValue = new TokenRequest<ApproveNoteRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteapprovedrecord/ApproveNote";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<ApproveNoteRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteApprovedRecord>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteApprovedRecordManager", "ApproveNoteAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<List<NoteApprovedRecord>>> GetNoteApprovedRecordsByUserIdAsync(GetNoteApprovedRecordsByUserIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteApprovedRecordsByUserIdRequest> requestValue = new TokenRequest<GetNoteApprovedRecordsByUserIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteapprovedrecord/GetNoteApprovedRecordsByUserId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteApprovedRecordsByUserIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<List<NoteApprovedRecord>>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteApprovedRecordManager", "GetNoteApprovedRecordsByUserIdAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<List<NoteApprovedRecord>>> GetNoteApprovedRecordsByNoteIdAsync(GetNoteApprovedRecordsByNoteIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteApprovedRecordsByNoteIdRequest> requestValue = new TokenRequest<GetNoteApprovedRecordsByNoteIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteapprovedrecord/GetNoteApprovedRecordsByNoteId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteApprovedRecordsByNoteIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<List<NoteApprovedRecord>>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteApprovedRecordManager", "GetNoteApprovedRecordsByNoteIdAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<NoteApprovedRecord>> GetNoteApprovedRecordByNoteIdAndUserIdAsync(GetNoteApprovedRecordsByNoteIdAndUserIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteApprovedRecordsByNoteIdAndUserIdRequest> requestValue = new TokenRequest<GetNoteApprovedRecordsByNoteIdAndUserIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteapprovedrecord/GetNoteApprovedRecordByNoteIdAndUserId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteApprovedRecordsByNoteIdAndUserIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteApprovedRecord>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteApprovedRecordManager", "GetNoteApprovedRecordByNoteIdAndUserId", "HTTP响应失败：" + requestUri);
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
