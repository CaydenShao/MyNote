using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpParamsOfNoteApprovedRecord
    {
        #region Sp_IUGetApproved_NoteApprovedRecord

        /// <summary>
        /// Sp_IUGetApproved_NoteApprovedRecord的参数1：UserId
        /// </summary>
        public const string Sp_IUGetApproved_NoteApprovedRecord_UserId = "UserId";
        /// <summary>
        /// Sp_IUGetApproved_NoteApprovedRecord的参数2：NoteId
        /// </summary>
        public const string Sp_IUGetApproved_NoteApprovedRecord_NoteId = "NoteId";

        #endregion

        #region Sp_UCancel_NoteApprovedRecord

        /// <summary>
        /// Sp_UCancel_NoteApprovedRecord的参数1：UserId
        /// </summary>
        public const string Sp_UCancel_NoteApprovedRecord_UserId = "UserId";
        /// <summary>
        /// Sp_UCancel_NoteApprovedRecord的参数2：NoteId
        /// </summary>
        public const string Sp_UCancel_NoteApprovedRecord_NoteId = "NoteId";

        #endregion

        #region Sp_Select_NoteApprovedRecordsByNoteId

        /// <summary>
        /// Sp_Select_NoteApprovedRecordsByNoteId的第1个参数：NoteId
        /// </summary>
        public const string Sp_Select_NoteApprovedRecordsByNoteId_NoteId = "NoteId";

        #endregion

        #region Sp_Select_NoteApprovedRecordsByUserId

        /// <summary>
        /// Sp_Select_NoteApprovedRecordsByUserId的第1个参数：UserId
        /// </summary>
        public const string Sp_Select_NoteApprovedRecordsByUserId_UserId = "UserId";

        #endregion

        #region Sp_Select_NoteApprovedRecordByNoteIdAndUserId

        /// <summary>
        /// Sp_Select_NoteApprovedRecordByNoteIdAndUserId的第1个参数：NoteId
        /// </summary>
        public const string Sp_Select_NoteApprovedRecordByNoteIdAndUserId_NoteId = "NoteId";
        /// <summary>
        /// Sp_Select_NoteApprovedRecordByNoteIdAndUserId的第2个参数：UserId
        /// </summary>
        public const string Sp_Select_NoteApprovedRecordByNoteIdAndUserId_UserId = "UserId";

        #endregion
    }
}
