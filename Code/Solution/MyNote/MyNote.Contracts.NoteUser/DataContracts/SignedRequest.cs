using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts
{
    /// <summary>
    /// Web API使用安全签名的实现时所需的数据信息
    /// 1.检查timestamp 与系统时间是否相差在合理时间内，如10分钟
    /// 2.将appSecret、timestamp、nonce三个参数进行字典序排序
    /// 3.将三个参数字符串拼接成一个字符串进行SHA256加密
    /// 4.加密后的字符串可与signature对比，若匹配则标识该次请求来源于某应用端，请求是合法的
    /// </summary>
    public class SignedRequest<T> : SignatureRequired
    {
        public T RequestData { get; set; }
    }
}
