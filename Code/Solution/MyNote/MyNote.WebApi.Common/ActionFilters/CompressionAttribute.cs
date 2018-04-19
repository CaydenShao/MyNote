using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.WebApi.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MyNote.WebApi.Common.ActionFilters
{
    /// <summary>
    /// HttpClient httpClient = new HttpClient(new HttpClientHandler{ AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
    /// httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
    /// 或httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CompressionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                HttpContent content = actionExecutedContext.Response.Content;
                List<StringWithQualityHeaderValue> acceptEncoding = actionExecutedContext.Request.Headers.AcceptEncoding.
                    Where(x => x.Value == "gzip" || x.Value == "deflate").ToList();

                if (acceptEncoding != null && acceptEncoding.Count > 0 && content != null
                    && actionExecutedContext.Request.Method != HttpMethod.Options)
                {
                    StringWithQualityHeaderValue first = acceptEncoding.FirstOrDefault();

                    if (first != null)
                    {
                        byte[] bytes = content.ReadAsByteArrayAsync().Result;

                        switch (first.Value)
                        {
                            case "gzip":
                                actionExecutedContext.Response.Content = new ByteArrayContent(CompressionHelper.GZipBytes(bytes));
                                actionExecutedContext.Response.Content.Headers.Remove("Content-Type");
                                actionExecutedContext.Response.Content.Headers.Add("Content-Encoding", "gzip");
                                actionExecutedContext.Response.Content.Headers.Add("Content-Type", "application/json");
                                break;
                            case "deflate":
                                actionExecutedContext.Response.Content = new ByteArrayContent(CompressionHelper.DeflateBytes(bytes));
                                actionExecutedContext.Response.Content.Headers.Remove("Content-Type");
                                actionExecutedContext.Response.Content.Headers.Add("Content-Encoding", "deflate");
                                actionExecutedContext.Response.Content.Headers.Add("Content-Type", "application/json");
                                break;
                        }
                    }
                }

                base.OnActionExecuted(actionExecutedContext);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
            }
        }
    }
}
