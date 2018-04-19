using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpNamesOfCommentContent
    {
        /// <summary>
        /// 增加一条CommentContent记录，并返回添加成功的记录
        /// </summary>
        public const string Sp_Insert_CommentContent = "Sp_Insert_CommentContent";
        /// <summary>
        /// 通过Id获取CommentContent记录
        /// </summary>
        public const string Sp_Select_CommentContentById = "Sp_Select_CommentContentById";
        /// <summary>
        /// 通过CommentId获取CommentContent记录
        /// </summary>
        public const string Sp_Select_CommentContentByCommentId = "Sp_Select_CommentContentByCommentId";
    }
}
