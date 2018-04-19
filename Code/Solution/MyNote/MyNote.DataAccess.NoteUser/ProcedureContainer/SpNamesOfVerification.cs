using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.NoteUser.ProcedureContainer
{
    public static class SpNamesOfVerification
    {
        /// <summary>
        /// 如果存在手机号相同的则更新，否则添加一条Verification记录并返回更新或添加成功的记录
        /// </summary>
        public const string Sp_Put_Verification = "Sp_Put_Verification";
        /// <summary>
        /// 通过Id获取Verification记录
        /// </summary>
        public const string Sp_Select_VerificationById = "Sp_Select_VerificationById";
        /// <summary>
        /// 通过PhoneNumber获取Verification记录
        /// </summary>
        public const string Sp_Select_VerificationByPhoneNumber = "Sp_Select_VerificationByPhoneNumber";
    }
}
