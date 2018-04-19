using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Common.Helpers
{
    public class ArgumentVerify
    {
        /// <summary>
        /// 数据库日期格式验证
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static bool IsValidSqlDateTime(DateTime? datetime)
        {
            if (null != datetime)
            {
                if (((DateTime)datetime) < SqlDateTime.MinValue || (((DateTime)datetime) > SqlDateTime.MaxValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 手机号格式验证
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsMobilePhoneNumber(string source)
        {
            return RegexHelper.IsMobilePhoneNumber(source);
        }

        /// <summary>
        /// IPv4格式验证
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsIPv4(string source)
        {
            return RegexHelper.IsIPv4(source);
        }

        /// <summary>
        /// Guid格式验证
        /// </summary>
        /// <param name="source">Guid</param>
        /// <returns></returns>
        public static bool IsGuid(string source)
        {
            return RegexHelper.IsGuid(source);
        }

        /// <summary>
        /// Guid格式验证
        /// </summary>
        /// <param name="source">Guid</param>
        /// <returns></returns>
        public static bool IsPort(string source)
        {
            return RegexHelper.IsPort(source);
        }

        public static bool IsPort(int port)
        {
            if (port < 0 || port > 65535)
            {
                return false;
            }

            return true;
        }
    }
}
