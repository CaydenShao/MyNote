using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Config.ProcedureContainer
{
    public static class SpNamesOfSysInfo
    {
        /// <summary>
        /// 增加一条SysInfo记录，并返回添加成功的记录
        /// </summary>
        public const string Sp_Insert_SysInfo = "Sp_Insert_SysInfo";
        /// <summary>
        /// 通过Id获取SysInfo记录
        /// </summary>
        public const string Sp_Select_SysInfoById = "Sp_Select_SysInfoById";
        /// <summary>
        /// 通过Name获取SysInfo记录
        /// </summary>
        public const string Sp_Select_SysInfoByName = "Sp_Select_SysInfoByName";
    }
}
