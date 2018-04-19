using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts
{
    /// <summary>
    /// 用（Web API接口的访问方式 3）访问的数据
    /// 提供公开的接口调用，不需要传入用户令牌、或者对参数进行加密签名的，这种接口一般较少，只是提供一些很常规的数据显示而已。
    /// </summary>
    public class PublicRequest<T> : PublicRequired
    {
        public T RequestData { get; set; }
    }
}
