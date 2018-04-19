using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.NoteUser.ProcedureContainer
{
    public static class SpParamsOfNoteUser
    {
        #region Sp_Insert_NoteUser

        /// <summary>
        /// Sp_Insert_NoteUser的参数1：Name
        /// </summary>
        public const string Sp_Insert_NoteUser_Name = "Name";
        /// <summary>
        /// Sp_Insert_NoteUser的参数2：PhoneNumber
        /// </summary>
        public const string Sp_Insert_NoteUser_PhoneNumber = "PhoneNumber";
        /// <summary>
        /// Sp_Insert_NoteUser的参数3：HashCode
        /// </summary>
        public const string Sp_Insert_NoteUser_HashCode = "HashCode";
        /// <summary>
        /// Sp_Insert_NoteUser的参数4：Salt
        /// </summary>
        public const string Sp_Insert_NoteUser_Salt = "Salt";
        /// <summary>
        /// Sp_Insert_NoteUser的参数5：LastLoginAddress
        /// </summary>
        public const string Sp_Insert_NoteUser_LastLoginAddress = "LastLoginAddress";

        #endregion

        #region Sp_Select_NoteUserById

        /// <summary>
        /// Sp_Select_NoteUserById的参数1：Id
        /// </summary>
        public const string Sp_Select_NoteUserById_Id = "Id";

        #endregion

        #region Sp_Select_NoteUserByPhoneNumber

        /// <summary>
        /// Sp_Select_NoteUserByAccount的参数1:Account
        /// </summary>
        public const string Sp_Select_NoteUserByPhoneNumber_PhoneNumber = "PhoneNumber";

        #endregion

        #region Sp_Select_NoteUserByToken

        /// <summary>
        /// Sp_Select_NoteUserByToken的参数1：Token
        /// </summary>
        public const string Sp_Select_NoteUserByToken_Token = "Token";

        #endregion

        #region Sp_Select_NoteUserByIdAndToken

        /// <summary>
        /// Sp_Select_NoteUserByIdAndToken的参数1：Id
        /// </summary>
        public const string Sp_Select_NoteUserByIdAndToken_Id = "Id";
        /// <summary>
        /// Sp_Select_NoteUserByIdAndToken的参数2：Token
        /// </summary>
        public const string Sp_Select_NoteUserByIdAndToken_Token = "Token";

        #endregion

        #region Sp_Update_NoteUserToken

        /// <summary>
        /// Sp_Update_NoteUserToken的参数1:Id
        /// </summary>
        public const string Sp_Update_NoteUserToken_Id = "Id";
        /// <summary>
        /// Sp_Update_NoteUserToken的参数2:Token
        /// </summary>
        public const string Sp_Update_NoteUserToken_Token = "Token";

        #endregion
    }
}
