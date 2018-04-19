using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Common.Helpers
{
    /// <summary>
    /// HttpClient内部维持一个专有的连接池，每个HttpClient实例的请求相互隔绝
    /// 在使用HttpClient时：
    /// •将其定义为单例模式（由单独的HttpClient维护连接池）
    /// •不要使用using关键字包裹（无效，套接字资源不会跟随释放）
    /// •尽量不要额外改变 HttpClient 的一些特殊行为（如上文中的TimeOut）
    /// •当你需要配置不同的Http请求时，允许生成并使用多个HttpClient
    /// </summary>
    public sealed class HttpClientHelper
    {
        public static readonly HttpClient Client;

        #region Constructors

        private HttpClientHelper()
        { }

        static HttpClientHelper()
        {
            Client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            });

            Client.Timeout = TimeSpan.FromSeconds(15);
            Client.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
            Client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
        }

        #endregion
    }
}
