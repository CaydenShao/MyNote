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
    public class NoteBrowsedRecordManager : ManagerBase
    {
        #region Constructors

        public NoteBrowsedRecordManager(string baseAddr) : base(baseAddr)
        {

        }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<NoteBrowsedRecord> AddNoteBrowsedRecord(AddNoteBrowsedRecordRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddNoteBrowsedRecordRequest> requestValue = new TokenRequest<AddNoteBrowsedRecordRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notebrowsedrecord/AddNoteBrowsedRecord";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddNoteBrowsedRecordRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<NoteBrowsedRecord>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteBrowsedRecordManager", "AddNoteBrowsedRecord", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByNoteId(GetNoteBrowsedRecordsByNoteIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteBrowsedRecordsByNoteIdRequest> requestValue = new TokenRequest<GetNoteBrowsedRecordsByNoteIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notebrowsedrecord/GetNoteBrowsedRecordsByNoteId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteBrowsedRecordsByNoteIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<List<NoteBrowsedRecord>>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteBrowsedRecordManager", "GetNoteBrowsedRecordsByNoteId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByUserId(GetNoteBrowsedRecordsByUserIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteBrowsedRecordsByUserIdRequest> requestValue = new TokenRequest<GetNoteBrowsedRecordsByUserIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notebrowsedrecord/GetNoteBrowsedRecordsByNoteId";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteBrowsedRecordsByUserIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<List<NoteBrowsedRecord>>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteBrowsedRecordManager", "GetNoteBrowsedRecordsByUserId", "HTTP响应失败：" + requestUri);
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

        public async Task<Response<NoteBrowsedRecord>> AddNoteBrowsedRecordAsync(AddNoteBrowsedRecordRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<AddNoteBrowsedRecordRequest> requestValue = new TokenRequest<AddNoteBrowsedRecordRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notebrowsedrecord/AddNoteBrowsedRecord";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<AddNoteBrowsedRecordRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<NoteBrowsedRecord>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteBrowsedRecordManager", "AddNoteBrowsedRecordAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<List<NoteBrowsedRecord>>> GetNoteBrowsedRecordsByNoteIdAsync(GetNoteBrowsedRecordsByNoteIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteBrowsedRecordsByNoteIdRequest> requestValue = new TokenRequest<GetNoteBrowsedRecordsByNoteIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notebrowsedrecord/GetNoteBrowsedRecordsByNoteId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteBrowsedRecordsByNoteIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<List<NoteBrowsedRecord>>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteBrowsedRecordManager", "GetNoteBrowsedRecordsByNoteId", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<List<NoteBrowsedRecord>>> GetNoteBrowsedRecordsByUserIdAsync(GetNoteBrowsedRecordsByUserIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetNoteBrowsedRecordsByUserIdRequest> requestValue = new TokenRequest<GetNoteBrowsedRecordsByUserIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/notebrowsedrecord/GetNoteBrowsedRecordsByNoteId";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetNoteBrowsedRecordsByUserIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<List<NoteBrowsedRecord>>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "NoteBrowsedRecordManager", "GetNoteBrowsedRecordsByUserId", "HTTP响应失败：" + requestUri);
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
