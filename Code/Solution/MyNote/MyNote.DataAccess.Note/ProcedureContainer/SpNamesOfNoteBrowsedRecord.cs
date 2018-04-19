using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpNamesOfNoteBrowsedRecord
    {
        /// <summary>
        /// 添加一条NoteBrowsedRecord记录
        /// </summary>
        public const string Sp_Add_NoteBrowsedRecord = "Sp_Add_NoteBrowsedRecord";
        /// <summary>
        /// 根据NoteId获取NoteBrowsedRecord记录
        /// </summary>
        public const string Sp_Select_NoteBrowsedRecordsByNoteId = "Sp_Select_NoteBrowsedRecordsByNoteId";
        /// <summary>
        /// 根据UserId获取NoteBrowsedRecord记录
        /// </summary>
        public const string Sp_Select_NoteBrowsedRecordsByUserId = "Sp_Select_NoteBrowsedRecordsByUserId";
    }
}
