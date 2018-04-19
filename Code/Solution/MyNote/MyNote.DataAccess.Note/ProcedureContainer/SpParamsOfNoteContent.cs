using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpParamsOfNoteContent
    {
        #region Sp_Insert_NoteContent

        /// <summary>
        /// Sp_Insert_NoteContent的参数1：NoteId
        /// </summary>
        public const string Sp_Insert_NoteContent_NoteId = "NoteId";
        /// <summary>
        /// Sp_Insert_NoteContent的参数2：Type
        /// </summary>
        public const string Sp_Insert_NoteContent_Type = "Type";
        /// <summary>
        /// Sp_Insert_NoteContent的参数3：Content
        /// </summary>
        public const string Sp_Insert_NoteContent_Content = "Content";

        #endregion

        #region Sp_Select_NoteContentById

        /// <summary>
        /// Sp_Select_NoteContentById的参数1：Id
        /// </summary>
        public const string Sp_Select_NoteContentById_Id = "Id";

        #endregion

        #region Sp_Select_NoteContentByNoteId

        /// <summary>
        /// Sp_Select_NoteContentByNoteId的参数1：NoteId
        /// </summary>
        public const string Sp_Select_NoteContentByNoteId_NoteId = "NoteId";

        #endregion
    }
}
