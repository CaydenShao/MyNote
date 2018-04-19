using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts;
using MyNoteWebApiClient.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using MyNoteWebApiClient.Models;
using MyNote.Contracts.DataContracts.Config;
using MyNote.Contracts.DataContracts.Config.Requests;

namespace MyNoteWebApiClient.Managements.Config
{
    public class SysInfoManager : ManagerBase
    {
        #region Constructors

        public SysInfoManager(string _baseAddr) : base(_baseAddr)
        { }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<DateTime> GetServerDateTime(PublicCheckInfo publicCheckInfo)
        {
            try
            {
                PublicRequest<object> requestValue = new PublicRequest<object>()
                {
                    RequestData = null,
                    Version = string.Empty
                };

                string requestUri = this.baseAddr + @"api/sysinfo/GetServerDateTime";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<PublicRequest<object>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<DateTime>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "SysInfoManager", "GetServerDateTime", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SysInfo> GetSysInfoById(GetSysInfoByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetSysInfoByIdRequest> requestValue = new TokenRequest<GetSysInfoByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/sysinfo/GetSysInfoById";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetSysInfoByIdRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SysInfo>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "SysInfoManager", "GetSysInfoById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SysInfo> GetSysInfoByName(GetSysInfoByNameRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetSysInfoByNameRequest> requestValue = new TokenRequest<GetSysInfoByNameRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/sysinfo/GetSysInfoByName";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetSysInfoByNameRequest>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SysInfo>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "SysInfoManager", "GetSysInfoByName", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<SysInfo> AddSysInfo(SysInfo sysInfo, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SysInfo> requestValue = new TokenRequest<SysInfo>()
                {
                    RequestData = sysInfo,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/sysinfo/AddSysInfo";
                HttpResponseMessage responseMessage = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SysInfo>>(requestUri, requestValue).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Response<SysInfo>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "SysInfoManager", "AddSysInfo", "HTTP响应失败：" + requestUri);
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

        public async Task<Response<DateTime>> GetServerDateTimeAsync(PublicRequest<object> request)
        {
            try
            {
                PublicRequest<object> requestValue = new PublicRequest<object>()
                {
                    RequestData = null,
                    Version = string.Empty
                };

                string requestUri = this.baseAddr + @"api/sysinfo/GetServerDateTime";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<PublicRequest<object>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<DateTime>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "GetServerDateTimeAsync", "GetServerDateTime", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SysInfo>> GetSysInfoByIdAsync(GetSysInfoByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetSysInfoByIdRequest> requestValue = new TokenRequest<GetSysInfoByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/sysinfo/GetSysInfoById";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetSysInfoByIdRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SysInfo>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "SysInfoManager", "GetSysInfoByIdAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SysInfo>> GetSysInfoByNameAsync(GetSysInfoByNameRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetSysInfoByNameRequest> requestValue = new TokenRequest<GetSysInfoByNameRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/sysinfo/GetSysInfoByName";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetSysInfoByNameRequest>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SysInfo>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "SysInfoManager", "GetSysInfoByNameAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<SysInfo>> AddSysInfoAsync(SysInfo sysInfo, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<SysInfo> requestValue = new TokenRequest<SysInfo>()
                {
                    RequestData = sysInfo,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/sysinfo/AddSysInfo";
                HttpResponseMessage responseMessage = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<SysInfo>>(requestUri, requestValue);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<Response<SysInfo>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "SysInfoManager", "AddSysInfoAsync", "HTTP响应失败：" + requestUri);
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
