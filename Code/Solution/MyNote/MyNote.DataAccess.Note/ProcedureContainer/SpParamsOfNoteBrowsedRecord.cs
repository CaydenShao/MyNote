using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpParamsOfNoteBrowsedRecord
    {
        #region Sp_Add_NoteBrowsedRecord

        /// <summary>
        /// Sp_Add_NoteBrowsedRecord的参数1：UserId
        /// </summary>
        public const string Sp_Add_NoteBrowsedRecord_UserId = "UserId";
        /// <summary>
        /// Sp_Add_NoteBrowsedRecord的参数2：NoteId
        /// </summary>
        public const string Sp_Add_NoteBrowsedRecord_NoteId = "NoteId";

        #endregion

        #region Sp_Select_NoteBrowsedRecordsByNoteId

        /// <summary>
        /// Sp_Select_NoteBrowsedRecordsByNoteId的参数1：NoteId
        /// </summary>
        public const string Sp_Select_NoteBrowsedRecordsByNoteId_NoteId = "NoteId";

        #endregion

        #region Sp_Select_NoteBrowsedRecordsByUserId

        /// <summary>
        /// Sp_Select_NoteBrowsedRecordsByUserId的参数1：UserId
        /// </summary>
        public const string Sp_Select_NoteBrowsedRecordsByUserId_UserId = "UserId";

        #endregion
    }
}
