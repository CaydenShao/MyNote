using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Config.ProcedureContainer
{
    public static class SpParamsOfSysInfo
    {
        #region Sp_Insert_SysInfo

        /// <summary>
        /// Sp_Insert_SysInfo的参数1：Name
        /// </summary>
        public const string Sp_Insert_SysInfo_Name = "Name";
        /// <summary>
        /// Sp_Insert_SysInfo的参数2：Description
        /// </summary>
        public const string Sp_Insert_SysInfo_Description = "Description";
        /// <summary>
        /// Sp_Insert_SysInfo的参数3：Detail
        /// </summary>
        public const string Sp_Insert_SysInfo_Detail = "Detail";

        #endregion

        #region Sp_Select_SysInfoById

        /// <summary>
        /// Sp_Select_SysInfoById的参数1：Id
        /// </summary>
        public const string Sp_Select_SysInfoById_Id = "Id";

        #endregion

        #region Sp_Select_SysInfoByName

        /// <summary>
        /// Sp_Select_SysInfoByName的参数1：Name
        /// </summary>
        public const string Sp_Select_SysInfoByName_Name = "Name";

        #endregion
    }
}
