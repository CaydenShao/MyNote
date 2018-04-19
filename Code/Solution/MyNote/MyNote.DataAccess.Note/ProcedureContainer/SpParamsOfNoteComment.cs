using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpParamsOfNoteComment
    {
        #region Sp_Insert_NoteComment

        /// <summary>
        /// Sp_Insert_NoteComment的参数1：NoteId
        /// </summary>
        public const string Sp_Insert_NoteComment_NoteId = "NoteId";
        /// <summary>
        /// Sp_Insert_NoteComment的参数2：CreatorId
        /// </summary>
        public const string Sp_Insert_NoteComment_CreatorId = "CreatorId";
        /// <summary>
        /// Sp_Insert_NoteComment的参数3：CommentId
        /// </summary>
        public const string Sp_Insert_NoteComment_CommentId = "CommentId";

        #endregion

        #region Sp_Select_NoteCommentById

        /// <summary>
        /// Sp_Insert_NoteCommentById的参数1：Id
        /// </summary>
        public const string Sp_Select_NoteCommentById_Id = "Id";

        #endregion

        #region Sp_Select_NoteCommentByNoteId

        /// <summary>
        /// Sp_Select_NoteCommentByNoteId的参数1：NoteId
        /// </summary>
        public const string Sp_Select_NoteCommentByNoteId_NoteId = "NoteId";

        #endregion
    }
}
