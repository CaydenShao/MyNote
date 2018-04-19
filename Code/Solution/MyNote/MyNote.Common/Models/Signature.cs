using MyNote.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Common.Models
{
    public class Signature
    {
        /// <summary>
        /// timestamp格式
        /// </summary>
        public const string TimeStampFormat = "yyyyMMddHHmmssffff";
        /// <summary>
        /// 检查timestamp 与系统时间是否相差在合理时间内,如10分钟。
        /// </summary>
        public const double TimspanExpiredMinutes = 10;

        private string appId = string.Empty;
        private string nonce = string.Empty;
        private string timestamp = string.Empty;
        private string signature = string.Empty;

        #region Constructors

        public Signature(string _appId, string _nonce, string _timestamp)
        {
            this.appId = _appId;
            this.nonce = _nonce;
            this.timestamp = _timestamp;
            this.signature = SHA256CrypHelper.GetHashStr(this.appId + this.nonce + this.timestamp);
        }

        public Signature(string _appId, string _nonce, DateTime _timestamp)
        {
            this.appId = _appId;
            this.nonce = _nonce;
            this.timestamp = _timestamp.ToString(Signature.TimeStampFormat);
            this.signature = SHA256CrypHelper.GetHashStr(this.appId + this.nonce + this.timestamp);
        }

        public Signature(string _appId)
        {
            this.appId = _appId;
            this.nonce = Guid.NewGuid().ToString();
            this.timestamp = DateTime.Now.ToString(Signature.TimeStampFormat);
            this.signature = SHA256CrypHelper.GetHashStr(this.appId + this.nonce + this.timestamp);
        }

        #endregion

        #region Properties

        public string AppId
        {
            get
            {
                return this.appId;
            }
        }

        public string Nonce
        {
            get
            {
                return this.nonce;
            }
        }

        public string TimeStamp
        {
            get
            {
                return this.timestamp;
            }
        }

        public string Sign
        {
            get
            {
                return this.signature;
            }
        }

        #endregion

        #region Public methods

        public static Signature NewSignature(string _appId)
        {
            return new Signature(_appId);
        }

        /// <summary>
        /// 进行签名检查
        /// </summary>
        /// <param name="signature">签名</param>
        /// <param name="timestamp">时间戳（ToString("yyyyMMddHHmmssffff")）</param>
        /// <param name="nonce">随机数</param>
        /// <param name="appid">应用接入ID</param>
        /// <returns></returns>
        public static SignCheckResult ValidateSignature(string signature, string timestamp, string nonce, string appid)
        {
            SignCheckResult result = new SignCheckResult()
            {
                IsSuccess = false,
                Description = "签名完整性检查不通过！"
            };

            if (string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(nonce) || string.IsNullOrEmpty(appid))
            {
                result.IsSuccess = false;
                result.Description = "所需的字段为空！";
                return result;
            }

            string hashStr = SHA256CrypHelper.GetHashStr(appid + nonce + timestamp);

            if (hashStr == signature)
            {
                DateTime dtTime;

                try
                {
                    dtTime = DateTime.ParseExact(timestamp, Signature.TimeStampFormat, CultureInfo.CurrentCulture);
                }
                catch (Exception ex)
                {
                    result.Description = "时间戳格式错误！";
                    return result;
                }

                double minutes = DateTime.Now.Subtract(dtTime).TotalMinutes;

                if (minutes > TimspanExpiredMinutes)
                {
                    result.Description = "签名时间戳失效！";
                }
                else
                {
                    result.Description = "签名验证成功！";
                    result.IsSuccess = true;
                }
            }

            return result;
        }

        #endregion
    }
}
