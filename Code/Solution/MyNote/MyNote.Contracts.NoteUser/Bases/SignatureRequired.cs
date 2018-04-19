using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.Bases
{
    public class SignatureRequired : RequestBase
    {
        /// <summary>
        /// 加密签名字符串
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// 应用接入ID
        /// Web API 为各种应用接入，如APP、Web、Winform等接入端分配应用AppID以及通信密钥AppSecret，双方各自存储。
        /// </summary>
        public string AppId { get; set; }
    }
}
