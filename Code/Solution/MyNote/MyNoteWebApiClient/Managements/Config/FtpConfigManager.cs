using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Config;
using MyNote.Contracts.DataContracts.Config.Requests;
using MyNoteWebApiClient.Bases;
using MyNoteWebApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteWebApiClient.Managements.Config
{
    public class FtpConfigManager : ManagerBase
    {
        #region Constructors

        public FtpConfigManager(string baseAddr) : base(baseAddr)
        {

        }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<FtpConfig> AddFtpConfig(FtpConfig ftpConfig, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<FtpConfig> requestValue = new TokenRequest<FtpConfig>()
                {
                    RequestData = ftpConfig,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/ftpconfig/AddFtpConfig";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<FtpConfig>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<FtpConfig>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "FtpConfigManager", "AddFtpConfig", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<FtpConfig> GetFtpConfigById(GetFtpConfigByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetFtpConfigByIdRequest> requestValue = new TokenRequest<GetFtpConfigByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/ftpconfig/GetFtpConfigById";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetFtpConfigByIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<FtpConfig>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "FtpConfigManager", "GetFtpConfigById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<FtpConfig> GetFtpConfigByName(GetFtpConfigByNameRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetFtpConfigByNameRequest> requestValue = new TokenRequest<GetFtpConfigByNameRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/ftpconfig/GetFtpConfigByName";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetFtpConfigByNameRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<FtpConfig>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "FtpConfigManager", "GetFtpConfigByName", "HTTP响应失败：" + requestUri);
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

        public async Task<Response<FtpConfig>> AddFtpConfigAsync(FtpConfig ftpConfig, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<FtpConfig> requestValue = new TokenRequest<FtpConfig>()
                {
                    RequestData = ftpConfig,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/ftpconfig/AddFtpConfig";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<FtpConfig>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<FtpConfig>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "FtpConfigManager", "AddFtpConfigAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<FtpConfig>> GetFtpConfigByIdAsync(GetFtpConfigByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetFtpConfigByIdRequest> requestValue = new TokenRequest<GetFtpConfigByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/ftpconfig/GetFtpConfigById";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetFtpConfigByIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<FtpConfig>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "FtpConfigManager", "GetFtpConfigByIdAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<FtpConfig>> GetFtpConfigByNameAsync(GetFtpConfigByNameRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetFtpConfigByNameRequest> requestValue = new TokenRequest<GetFtpConfigByNameRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/ftpconfig/GetFtpConfigByName";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetFtpConfigByNameRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<FtpConfig>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "FtpConfigManager", "GetFtpConfigByNameAsync", "HTTP响应失败：" + requestUri);
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
