using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpNamesOfNoteApprovedRecord
    {
        /// <summary>
        /// 插入或更新记录为赞的NoteApprovedRecord记录
        /// </summary>
        public const string Sp_IUGetApproved_NoteApprovedRecord = "Sp_IUGetApproved_NoteApprovedRecord";
        /// <summary>
        /// 取消赞
        /// </summary>
        public const string Sp_UCancel_NoteApprovedRecord = "Sp_UCancel_NoteApprovedRecord";
        /// <summary>
        /// 根据NoteId获取NoteApprovedRecord记录
        /// </summary>
        public const string Sp_Select_NoteApprovedRecordsByNoteId = "Sp_Select_NoteApprovedRecordsByNoteId";
        /// <summary>
        /// 根据UserId获取NoteApprovedRecord记录
        /// </summary>
        public const string Sp_Select_NoteApprovedRecordsByUserId = "Sp_Select_NoteApprovedRecordsByUserId";
        /// <summary>
        /// 根据UserId和NoteId获取NoteApprovedRecord记录
        /// </summary>
        public const string Sp_Select_NoteApprovedRecordByNoteIdAndUserId = "Sp_Select_NoteApprovedRecordByNoteIdAndUserId";
    }
}
