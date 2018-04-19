using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace MyNote.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //var apiDll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyControllers.dll");
            //Assembly.LoadFrom(apiDll);

            HttpSelfHostConfiguration configuration =
                new HttpSelfHostConfiguration("http://localhost:80");
            // 若要使用特性路由功能需要先在Application_Start中开启映射到特性路由
            configuration.MapHttpAttributeRoutes();
            // 注册路由模板
            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            using (HttpSelfHostServer httpServer = new HttpSelfHostServer(configuration))
            {
                httpServer.OpenAsync();
                Console.Read();
            }
        }
    }
}
