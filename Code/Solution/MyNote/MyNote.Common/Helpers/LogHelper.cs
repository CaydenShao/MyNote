using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using MyNote.Common.Enums;

namespace MyNote.Common.Helpers
{
    public static class LogHelper
    {
        /// <summary>
        /// 配置key名称
        /// </summary>
        public static readonly string AppLogSettingKey = "AppLogPath";
        public static readonly string Fatal = "Fatal";
        public static readonly string Error = "Error";
        public static readonly string Warn = "Warn";
        public static readonly string Info = "Info";
        public static readonly string Debug = "Debug";

        private readonly static string rootPath = string.Empty;
        private readonly static string fatalPath = string.Empty;
        private readonly static string errorPath = string.Empty;
        private readonly static string warnPath = string.Empty;
        private readonly static string infoPath = string.Empty;
        private readonly static string debugPath = string.Empty;

        #region Constructors

        static LogHelper()
        {
            string setLogPath = ConfigurationManager.AppSettings[AppLogSettingKey];

            if (string.IsNullOrEmpty(setLogPath))
            {
                rootPath = AppDomain.CurrentDomain.BaseDirectory + "Log\\";
            }
            else
            {
                rootPath = Path.GetFullPath(setLogPath) + "\\Log\\";
            }

            fatalPath = rootPath + Fatal + "\\";
            errorPath = rootPath + Error + "\\";
            warnPath = rootPath + Warn + "\\";
            infoPath = rootPath + Info + "\\";
            debugPath = rootPath + Debug + "\\";
        }

        #endregion

        #region Properties

        public static string RootPath
        {
            get
            {
                return rootPath;
            }
        }

        public static string FatalPath
        {
            get
            {
                return fatalPath;
            }
        }

        public static string ErrorPath
        {
            get
            {
                return errorPath;
            }
        }

        public static string WarnPath
        {
            get
            {
                return warnPath;
            }
        }

        public static string InfoPath
        {
            get
            {
                return infoPath;
            }
        }

        public static string DebugPath
        {
            get
            {
                return debugPath;
            }
        }

        #endregion

        #region Public methods

        public static void WriteFatal(Exception ex)
        {
            if (!Directory.Exists(fatalPath))
            {
                Directory.CreateDirectory(fatalPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (ex != null)
            {
                // 获取描述当前的异常信息
                logInfo.Append("Message:" + ex.Message + Environment.NewLine);
                // 获取当前实例的运行时类型
                logInfo.Append("Type:" + ex.GetType() + Environment.NewLine);
                // 获取或设置导致错误的应用程序或对象的名称
                logInfo.Append("Source:" + ex.Source + Environment.NewLine);
                // 获取引发当前异常的方法
                logInfo.Append("Method:" + ex.TargetSite + Environment.NewLine);
                // 获取调用堆栈上直接帧的字符串表示形式
                logInfo.Append("StackTrace:" + ex.StackTrace + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(fatalPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteFatal(string content)
        {
            if (!Directory.Exists(fatalPath))
            {
                Directory.CreateDirectory(fatalPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (!string.IsNullOrWhiteSpace(content))
            {
                logInfo.Append(content + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(fatalPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteFatal(string typeName, string methodName, string info)
        {
            if (string.IsNullOrEmpty(typeName) || string.IsNullOrEmpty(methodName))
            {
                return;
            }

            if (!Directory.Exists(fatalPath))
            {
                Directory.CreateDirectory(fatalPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);
            logInfo.Append("Type:" + typeName + Environment.NewLine);
            logInfo.Append("MethodName:" + methodName + Environment.NewLine);
            logInfo.Append(info + Environment.NewLine);
            logInfo.Append(Environment.NewLine);
            File.AppendAllText(fatalPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteError(Exception ex)
        {
            if (!Directory.Exists(errorPath))
            {
                Directory.CreateDirectory(errorPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (ex != null)
            {
                // 获取描述当前的异常信息
                logInfo.Append("Message:" + ex.Message + Environment.NewLine);
                // 获取当前实例的运行时类型
                logInfo.Append("Type:" + ex.GetType() + Environment.NewLine);
                // 获取或设置导致错误的应用程序或对象的名称
                logInfo.Append("Source:" + ex.Source + Environment.NewLine);
                // 获取引发当前异常的方法
                logInfo.Append("Method:" + ex.TargetSite + Environment.NewLine);
                // 获取调用堆栈上直接帧的字符串表示形式
                logInfo.Append("StackTrace:" + ex.StackTrace + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(errorPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteError(string content)
        {
            if (!Directory.Exists(errorPath))
            {
                Directory.CreateDirectory(errorPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (!string.IsNullOrWhiteSpace(content))
            {
                logInfo.Append(content + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(errorPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteError(string typeName, string methodName, string info)
        {
            if (string.IsNullOrEmpty(typeName) || string.IsNullOrEmpty(methodName))
            {
                return;
            }

            if (!Directory.Exists(errorPath))
            {
                Directory.CreateDirectory(errorPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);
            logInfo.Append("Type:" + typeName + Environment.NewLine);
            logInfo.Append("MethodName:" + methodName + Environment.NewLine);
            logInfo.Append(info + Environment.NewLine);
            logInfo.Append(Environment.NewLine);
            File.AppendAllText(errorPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteWarn(Exception ex)
        {
            if (!Directory.Exists(warnPath))
            {
                Directory.CreateDirectory(warnPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (ex != null)
            {
                // 获取描述当前的异常信息
                logInfo.Append("Message:" + ex.Message + Environment.NewLine);
                // 获取当前实例的运行时类型
                logInfo.Append("Type:" + ex.GetType() + Environment.NewLine);
                // 获取或设置导致错误的应用程序或对象的名称
                logInfo.Append("Source:" + ex.Source + Environment.NewLine);
                // 获取引发当前异常的方法
                logInfo.Append("Method:" + ex.TargetSite + Environment.NewLine);
                // 获取调用堆栈上直接帧的字符串表示形式
                logInfo.Append("StackTrace:" + ex.StackTrace + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(warnPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteWarn(string content)
        {
            if (!Directory.Exists(warnPath))
            {
                Directory.CreateDirectory(warnPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (!string.IsNullOrWhiteSpace(content))
            {
                logInfo.Append(content + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(warnPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteWarn(string typeName, string methodName, string info)
        {
            if (string.IsNullOrEmpty(typeName) || string.IsNullOrEmpty(methodName))
            {
                return;
            }

            if (!Directory.Exists(warnPath))
            {
                Directory.CreateDirectory(warnPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);
            logInfo.Append("Type:" + typeName + Environment.NewLine);
            logInfo.Append("MethodName:" + methodName + Environment.NewLine);
            logInfo.Append(info + Environment.NewLine);
            logInfo.Append(Environment.NewLine);
            File.AppendAllText(warnPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteInfo(Exception ex)
        {
            if (!Directory.Exists(infoPath))
            {
                Directory.CreateDirectory(infoPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (ex != null)
            {
                // 获取描述当前的异常信息
                logInfo.Append("Message:" + ex.Message + Environment.NewLine);
                // 获取当前实例的运行时类型
                logInfo.Append("Type:" + ex.GetType() + Environment.NewLine);
                // 获取或设置导致错误的应用程序或对象的名称
                logInfo.Append("Source:" + ex.Source + Environment.NewLine);
                // 获取引发当前异常的方法
                logInfo.Append("Method:" + ex.TargetSite + Environment.NewLine);
                // 获取调用堆栈上直接帧的字符串表示形式
                logInfo.Append("StackTrace:" + ex.StackTrace + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(infoPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteInfo(string content)
        {
            if (!Directory.Exists(infoPath))
            {
                Directory.CreateDirectory(infoPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (!string.IsNullOrWhiteSpace(content))
            {
                logInfo.Append(content + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(infoPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteInfo(string typeName, string methodName, string info)
        {
            if (string.IsNullOrEmpty(typeName) || string.IsNullOrEmpty(methodName))
            {
                return;
            }

            if (!Directory.Exists(infoPath))
            {
                Directory.CreateDirectory(infoPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);
            logInfo.Append("Type:" + typeName + Environment.NewLine);
            logInfo.Append("MethodName:" + methodName + Environment.NewLine);
            logInfo.Append(info + Environment.NewLine);
            logInfo.Append(Environment.NewLine);
            File.AppendAllText(infoPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteDebug(Exception ex)
        {
            if (!Directory.Exists(debugPath))
            {
                Directory.CreateDirectory(debugPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (ex != null)
            {
                // 获取描述当前的异常信息
                logInfo.Append("Message:" + ex.Message + Environment.NewLine);
                // 获取当前实例的运行时类型
                logInfo.Append("Type:" + ex.GetType() + Environment.NewLine);
                // 获取或设置导致错误的应用程序或对象的名称
                logInfo.Append("Source:" + ex.Source + Environment.NewLine);
                // 获取引发当前异常的方法
                logInfo.Append("Method:" + ex.TargetSite + Environment.NewLine);
                // 获取调用堆栈上直接帧的字符串表示形式
                logInfo.Append("StackTrace:" + ex.StackTrace + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(debugPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteDebug(string content)
        {
            if (!Directory.Exists(debugPath))
            {
                Directory.CreateDirectory(debugPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (!string.IsNullOrWhiteSpace(content))
            {
                logInfo.Append(content + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(debugPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteDebug(string typeName, string methodName, string info)
        {
            if (string.IsNullOrEmpty(typeName) || string.IsNullOrEmpty(methodName))
            {
                return;
            }

            if (!Directory.Exists(debugPath))
            {
                Directory.CreateDirectory(debugPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);
            logInfo.Append("Type:" + typeName + Environment.NewLine);
            logInfo.Append("MethodName:" + methodName + Environment.NewLine);
            logInfo.Append(info + Environment.NewLine);
            logInfo.Append(Environment.NewLine);
            File.AppendAllText(debugPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteLog(LogType logType, Exception ex)
        {
            string currentPath = debugPath;

            if (logType == LogType.Fatal)
            {
                currentPath = fatalPath;
            }
            else if (logType == LogType.Warn)
            {
                currentPath = warnPath;
            }
            else if (logType == LogType.Error)
            {
                currentPath = errorPath;
            }
            else if (logType == LogType.Debug)
            {
                currentPath = debugPath;
            }
            else if (logType == LogType.Info)
            {
                currentPath = infoPath;
            }

            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (ex != null)
            {
                // 获取描述当前的异常信息
                logInfo.Append("Message:" + ex.Message + Environment.NewLine);
                // 获取当前实例的运行时类型
                logInfo.Append("Type:" + ex.GetType() + Environment.NewLine);
                // 获取或设置导致错误的应用程序或对象的名称
                logInfo.Append("Source:" + ex.Source + Environment.NewLine);
                // 获取引发当前异常的方法
                logInfo.Append("Method:" + ex.TargetSite + Environment.NewLine);
                // 获取调用堆栈上直接帧的字符串表示形式
                logInfo.Append("StackTrace:" + ex.StackTrace + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(currentPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteLog(LogType logType, string content)
        {
            string currentPath = debugPath;

            if (logType == LogType.Fatal)
            {
                currentPath = fatalPath;
            }
            else if (logType == LogType.Warn)
            {
                currentPath = warnPath;
            }
            else if (logType == LogType.Error)
            {
                currentPath = errorPath;
            }
            else if (logType == LogType.Debug)
            {
                currentPath = debugPath;
            }
            else if (logType == LogType.Info)
            {
                currentPath = infoPath;
            }

            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);

            if (!string.IsNullOrWhiteSpace(content))
            {
                logInfo.Append(content + Environment.NewLine);
            }

            logInfo.Append(Environment.NewLine);
            File.AppendAllText(currentPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        public static void WriteLog(LogType logType, string typeName, string methodName, string info)
        {
            if (string.IsNullOrEmpty(typeName) || string.IsNullOrEmpty(methodName))
            {
                return;
            }

            string currentPath = debugPath;

            if (logType == LogType.Fatal)
            {
                currentPath = fatalPath;
            }
            else if (logType == LogType.Warn)
            {
                currentPath = warnPath;
            }
            else if (logType == LogType.Error)
            {
                currentPath = errorPath;
            }
            else if (logType == LogType.Debug)
            {
                currentPath = debugPath;
            }
            else if (logType == LogType.Info)
            {
                currentPath = infoPath;
            }

            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }

            StringBuilder logInfo = new StringBuilder();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
            logInfo.Append(currentTime + Environment.NewLine);
            logInfo.Append("Type:" + typeName + Environment.NewLine);
            logInfo.Append("MethodName:" + methodName + Environment.NewLine);
            logInfo.Append(info + Environment.NewLine);
            logInfo.Append(Environment.NewLine);
            File.AppendAllText(currentPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

        #endregion
    }
}
