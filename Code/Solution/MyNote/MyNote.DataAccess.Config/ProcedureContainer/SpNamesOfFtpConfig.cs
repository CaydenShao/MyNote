using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Config.ProcedureContainer
{
    public static class SpNamesOfFtpConfig
    {
        /// <summary>
        /// 增加一条FtpConfig记录，并返回添加成功的记录
        /// </summary>
        public const string Sp_Insert_FtpConfig = "Sp_Insert_FtpConfig";
        /// <summary>
        /// 通过Id获取FtpConfig记录
        /// </summary>
        public const string Sp_Select_FtpConfigById = "Sp_Select_FtpConfigById";
        /// <summary>
        /// 通过名称获取FtpConfig记录
        /// </summary>
        public const string Sp_Select_FtpConfigByName = "Sp_Select_FtpConfigByName";
    }
}
