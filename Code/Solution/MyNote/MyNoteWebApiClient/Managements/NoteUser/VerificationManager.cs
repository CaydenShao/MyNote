using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Common.Models;
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
    public class VerificationManager : ManagerBase
    {
        #region Constructors

        public VerificationManager(string _baseAddr) : base(_baseAddr)
        {

        }

        #endregion

        #region Public methods

        #region Sync methods

        public Response<bool> GenerateVerification(GenerateVerificationRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);

                SignedRequest<GenerateVerificationRequest> requestValue = new SignedRequest<GenerateVerificationRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/verification/GenerateVerification";
                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<GenerateVerificationRequest>>(requestUri, requestValue).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<bool>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "VerificationManager", "GenerateVerification", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<Verification> GetVerificationByPhoneNumber(GetVerificationByPhoneNumberRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);

                SignedRequest<GetVerificationByPhoneNumberRequest> requestValue = new SignedRequest<GetVerificationByPhoneNumberRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/verification/GetVerificationByPhoneNumber";
                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<GetVerificationByPhoneNumberRequest>>(requestUri, requestValue).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<Verification>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "VerificationManager", "GetVerificationByPhoneNumber", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public Response<bool> CheckVerification(CheckVerificationRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);

                SignedRequest<CheckVerificationRequest> requestValue = new SignedRequest<CheckVerificationRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/verification/CheckVerification";
                HttpResponseMessage httpResponse = HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<CheckVerificationRequest>>(requestUri, requestValue).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsAsync<Response<bool>>().Result;
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "VerificationManager", "CheckVerification", "HTTP响应失败：" + requestUri);
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

        public async Task<Response<bool>> GenerateVerificationAsync(GenerateVerificationRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);

                SignedRequest<GenerateVerificationRequest> requestValue = new SignedRequest<GenerateVerificationRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/verification/GenerateVerification";
                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<GenerateVerificationRequest>>(requestUri, requestValue);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<bool>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "VerificationManager", "GenerateVerificationAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<Verification>> GetVerificationByPhoneNumberAsync(GetVerificationByPhoneNumberRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);

                SignedRequest<GetVerificationByPhoneNumberRequest> requestValue = new SignedRequest<GetVerificationByPhoneNumberRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/verification/GetVerificationByPhoneNumber";
                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<GetVerificationByPhoneNumberRequest>>(requestUri, requestValue);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<Verification>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "VerificationManager", "GetVerificationByPhoneNumberAsync", "HTTP响应失败：" + requestUri);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                return null;
            }
        }

        public async Task<Response<bool>> CheckVerificationAsync(CheckVerificationRequest request, SignatureCheckInfo signatureCheckInfo)
        {
            try
            {
                Signature signature = Signature.NewSignature(signatureCheckInfo.AppId);

                SignedRequest<CheckVerificationRequest> requestValue = new SignedRequest<CheckVerificationRequest>()
                {
                    RequestData = request,
                    AppId = signature.AppId,
                    Nonce = signature.Nonce,
                    TimeStamp = signature.TimeStamp,
                    Signature = signature.Sign,
                    Version = signatureCheckInfo.Version
                };

                string requestUri = this.baseAddr + @"api/verification/CheckVerification";
                HttpResponseMessage httpResponse = await HttpClientHelper.Client.PostAsJsonAsync<SignedRequest<CheckVerificationRequest>>(requestUri, requestValue);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsAsync<Response<bool>>();
                }
                else
                {
                    LogHelper.WriteLog(LogType.Error, "VerificationManager", "CheckVerificationAsync", "HTTP响应失败：" + requestUri);
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
