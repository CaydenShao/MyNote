using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpNamesOfNoteComment
    {
        /// <summary>
        /// 增加一条NoteComment记录，并返回添加成功的记录
        /// </summary>
        public const string Sp_Insert_NoteComment = "Sp_Insert_NoteComment";
        /// <summary>
        /// 通过Id获取NoteComment记录
        /// </summary>
        public const string Sp_Select_NoteCommentById = "Sp_Select_NoteCommentById";
        /// <summary>
        /// 通过NoteId获取NoteComment记录
        /// </summary>
        public const string Sp_Select_NoteCommentByNoteId = "Sp_Select_NoteCommentByNoteId";
    }
}
