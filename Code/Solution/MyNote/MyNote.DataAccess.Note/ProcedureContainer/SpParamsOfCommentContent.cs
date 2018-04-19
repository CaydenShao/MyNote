using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpParamsOfCommentContent
    {
        #region Sp_Insert_CommentContent

        /// <summary>
        /// Sp_Insert_CommentContent的参数1：CommentId
        /// </summary>
        public const string Sp_Insert_CommentContent_CommentId = "CommentId";
        /// <summary>
        /// Sp_Insert_CommentContent的参数2：Type
        /// </summary>
        public const string Sp_Insert_CommentContent_Type = "Type";
        /// <summary>
        /// Sp_Insert_CommentContent的参数3：Content
        /// </summary>
        public const string Sp_Insert_CommentContent_Content = "Content";

        #endregion

        #region Sp_Select_CommentContentById

        /// <summary>
        /// Sp_Select_CommentContentById的参数1：Id
        /// </summary>
        public const string Sp_Select_CommentContentById_Id = "Id";

        #endregion

        #region Sp_Select_CommentContentByCommentId

        /// <summary>
        /// Sp_Select_CommentContentByCommentId的参数1：CommentId
        /// </summary>
        public const string Sp_Select_CommentContentByCommentId_CommentId = "CommentId";

        #endregion
    }
}
