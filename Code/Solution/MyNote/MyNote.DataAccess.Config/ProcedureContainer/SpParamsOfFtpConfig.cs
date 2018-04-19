using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Config.ProcedureContainer
{
    public static class SpParamsOfFtpConfig
    {
        #region Sp_Insert_FtpConfig

        /// <summary>
        /// Sp_Insert_FtpConfig的参数1：Name
        /// </summary>
        public const string Sp_Insert_FtpConfig_Name = "Name";
        /// <summary>
        /// Sp_Insert_FtpConfig的参数2：Discription
        /// </summary>
        public const string Sp_Insert_FtpConfig_Discription = "Discription";
        /// <summary>
        /// Sp_Insert_FtpConfig的参数3：IP
        /// </summary>
        public const string Sp_Insert_FtpConfig_IP = "IP";
        /// <summary>
        /// Sp_Insert_FtpConfig的参数4：Port
        /// </summary>
        public const string Sp_Insert_FtpConfig_Port = "Port";
        /// <summary>
        /// Sp_Insert_FtpConfig的参数5：IsNeedAuthentication
        /// </summary>
        public const string Sp_Insert_FtpConfig_IsNeedAuthenticationt = "IsNeedAuthentication";
        /// <summary>
        /// Sp_Insert_FtpConfig的参数6：VirticalDir
        /// </summary>
        public const string Sp_Insert_FtpConfig_VirticalDir = "VirticalDir";
        /// <summary>
        /// Sp_Insert_FtpConfig的参数7：UserName
        /// </summary>
        public const string Sp_Insert_FtpConfig_UserName = "UserName";
        /// <summary>
        /// Sp_Insert_FtpConfig的参数8：Password
        /// </summary>
        public const string Sp_Insert_FtpConfig_Password = "Password";

        #endregion

        #region Sp_Select_FtpConfigById

        /// <summary>
        /// Sp_Select_FtpConfigById的参数1：Id
        /// </summary>
        public const string Sp_Select_FtpConfigById_Id = "Id";

        #endregion

        #region Sp_Select_FtpConfigByName

        /// <summary>
        /// Sp_Select_FtpConfigById的参数1：Name
        /// </summary>
        public const string Sp_Select_FtpConfigByName_Name = "Name";

        #endregion
    }
}
