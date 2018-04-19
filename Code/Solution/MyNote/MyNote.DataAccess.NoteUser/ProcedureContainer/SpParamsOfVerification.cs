using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.NoteUser.ProcedureContainer
{
    public static class SpParamsOfVerification
    {
        #region Sp_Insert_Verification

        /// <summary>
        /// Sp_Insert_Verification的参数1:PhoneNumber
        /// </summary>
        public const string Sp_Insert_Verification_PhoneNumber = "PhoneNumber";
        /// <summary>
        /// Sp_Insert_Verification的参数2:Code
        /// </summary>
        public const string Sp_Insert_Verification_Code = "Code";

        #endregion

        #region Sp_Select_VerificationById

        /// <summary>
        /// Sp_Select_VerificationById的参数1：Id
        /// </summary>
        public const string Sp_Select_VerificationById_Id = "Id";

        #endregion

        #region Sp_Select_VerificationByPhoneNumber

        /// <summary>
        /// Sp_Select_VerificationByPhoneNumber的参数1：PhoneNumber
        /// </summary>
        public const string Sp_Select_VerificationByPhoneNumber_PhoneNumber = "PhoneNumber";

        #endregion
    }
}
