using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpNamesOfNoteContent
    {
        /// <summary>
        /// 增加一条NoteContent记录，并返回添加成功的记录
        /// </summary>
        public const string Sp_Insert_NoteContent = "Sp_Insert_NoteContent";
        /// <summary>
        /// 通过Id获取NoteContent记录
        /// </summary>
        public const string Sp_Select_NoteContentById = "Sp_Select_NoteContentById";
        /// <summary>
        /// 通过NoteId获取NoteContent记录
        /// </summary>
        public const string Sp_Select_NoteContentByNoteId = "Sp_Select_NoteContentByNoteId";
    }
}
