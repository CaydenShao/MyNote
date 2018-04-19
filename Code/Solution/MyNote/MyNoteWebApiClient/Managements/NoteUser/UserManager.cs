using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Common.Models;
using MyNote.Contracts.Bases;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.Contracts.DataContracts.NoteUser.Requests;
using MyNoteWebApiClient.Bases;
using MyNoteWebApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteWebApiClient.Managements.NoteUser
{
    public class UserManager : ManagerBase
    {
        #region Constructors

        public UserManager(string _baseAddr) : base(_baseAddr)
        {
            
        }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<User> GetUserById(GetUserByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetUserByIdRequest> requestValue = new TokenRequest<GetUserByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteuser/GetUserById";
                //string json = JsonHelper.Serialized(requestValue);
                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetUserByIdRequest>>(requestUri, requestValue).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<User>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "GetUserById", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<User> GetUserByPhoneNumber(GetUserByPhoneNumberRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                string requestUri = this.baseAddr + @"api/noteuser/GetUserByPhoneNumber";

                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetUserByPhoneNumberRequest>>(requestUri, new TokenRequest<GetUserByPhoneNumberRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                }).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<User>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "GetUserByPhoneNumber", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<User> GetUserByToken(GetUserByTokenRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                string requestUri = this.baseAddr + @"api/noteuser/GetUserByToken";

                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetUserByTokenRequest>>(requestUri, new TokenRequest<GetUserByTokenRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                }).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<User>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "GetUserByToken", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<User> Login(LoginRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);
                string requestUri = this.baseAddr + @"api/noteuser/Login";

                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<LoginRequest>>(requestUri, new SignedRequest<LoginRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                }).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<User>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "Login", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<User> Register(RegisterRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);
                //将密码加密传输
                //password = SHA256CrypHelper.GetHashStr(password);
                string requestUri = this.baseAddr + @"api/noteuser/Register";

                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<RegisterRequest>>(requestUri, new SignedRequest<RegisterRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                }).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<User>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "Register", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<bool> CheckPhoneNumberRegistered(CheckPhoneNumberRegisteredRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);
                //将密码加密传输
                //password = SHA256CrypHelper.GetHashStr(password);
                string requestUri = this.baseAddr + @"api/noteuser/CheckPhoneNumberRegistered";

                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<CheckPhoneNumberRegisteredRequest>>(requestUri, new SignedRequest<CheckPhoneNumberRegisteredRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                }).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<bool>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "CheckPhoneNumberRegistered", "HTTP响应失败：" + requestUri);
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

        public async Task<Response<User>> GetUserByIdAsync(GetUserByIdRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                TokenRequest<GetUserByIdRequest> requestValue = new TokenRequest<GetUserByIdRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/noteuser/GetUserById";
                //string json = JsonHelper.Serialized(requestValue);
                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetUserByIdRequest>>(requestUri, requestValue);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<User>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "GetUserByIdAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<User>> GetUserByPhoneNumberAsync(GetUserByPhoneNumberRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                string requestUri = this.baseAddr + @"api/noteuser/GetUserByPhoneNumber";

                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetUserByPhoneNumberRequest>>(requestUri, new TokenRequest<GetUserByPhoneNumberRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                });

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<User>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "GetUserByPhoneNumberAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<User>> GetUserByTokenAsync(GetUserByTokenRequest request, TokenCheckInfo tokenCheckInfo)
        {
            try
            {
                string requestUri = this.baseAddr + @"api/noteuser/GetUserByToken";

                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<TokenRequest<GetUserByTokenRequest>>(requestUri, new TokenRequest<GetUserByTokenRequest>()
                {
                    RequestData = request,
                    Token = tokenCheckInfo.Token,
                    UserId = tokenCheckInfo.UserId,
                    Version = tokenCheckInfo.Version
                });

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<User>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "GetUserByTokenAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<User>> LoginAsync(LoginRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);
                string requestUri = this.baseAddr + @"api/noteuser/Login";

                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<LoginRequest>>(requestUri, new SignedRequest<LoginRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                });

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<User>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "LoginAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<User>> RegisterAsync(RegisterRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);
                //将密码加密传输
                //password = SHA256CrypHelper.GetHashStr(password);
                string requestUri = this.baseAddr + @"api/noteuser/Register";

                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<RegisterRequest>>(requestUri, new SignedRequest<RegisterRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                });

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<User>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "RegisterAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<bool>> CheckPhoneNumberRegisteredAsync(CheckPhoneNumberRegisteredRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);
                //将密码加密传输
                //password = SHA256CrypHelper.GetHashStr(password);
                string requestUri = this.baseAddr + @"api/noteuser/CheckPhoneNumberRegistered";

                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<CheckPhoneNumberRegisteredRequest>>(requestUri, new SignedRequest<CheckPhoneNumberRegisteredRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                });

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<bool>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "UserManager", "CheckPhoneNumberRegisteredAsync", "HTTP响应失败：" + requestUri);
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
