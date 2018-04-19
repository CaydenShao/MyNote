using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpNamesOfNote
    {
        /// <summary>
        /// 增加一条Note记录，并返回添加成功的记录
        /// </summary>
        public const string Sp_Insert_Note = "Sp_Insert_Note";
        /// <summary>
        /// 通过Id获取Note记录
        /// </summary>
        public const string Sp_Select_NoteById = "Sp_Select_NoteById";
        /// <summary>
        /// 通过AuthorId获取Note记录
        /// </summary>
        public const string Sp_Select_NoteByAuthorId = "Sp_Select_NoteByAuthorId";
        /// <summary>
        /// 通过Id获取Note的LastBrowsedTime字段，并更新为当前时间
        /// </summary>
        public const string Sp_Update_NoteGetBrowsed = "Sp_Update_NoteGetBrowsed";
        /// <summary>
        /// 通过Remark模糊查询实现分页搜索
        /// </summary>
        public const string Sp_Select_NoteSearchByRemark = "Sp_Select_NoteSearchByRemark";
        /// <summary>
        /// 通过Remark模糊查询和AuthorId的匹配实现分页搜索
        /// </summary>
        public const string Sp_Select_NoteSearchByRemarkAndAuthorId = "Sp_Select_NoteSearchByRemarkAndAuthorId";
        /// <summary>
        /// 通过Title模糊查询实现分页搜索
        /// </summary>
        public const string Sp_Select_NoteSearchByTitle = "Sp_Select_NoteSearchByTitle";
        /// <summary>
        /// 通过Title模糊查询和AuthorId的匹配实现分页搜索
        /// </summary>
        public const string Sp_Select_NoteSearchByTitleAndAuthorId = "Sp_Select_NoteSearchByTitleAndAuthorId";
        /// <summary>
        /// 通过时间段匹配实现分页搜索
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpan = "Sp_Select_NoteSearchByTimeSpan";
        /// <summary>
        /// 通过时间段和AuthorId匹配实现分页搜索
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpanAndAuthorId = "Sp_Select_NoteSearchByTimeSpanAndAuthorId";
        /// <summary>
        /// 通过AuthorId匹配实现分页搜索
        /// </summary>
        public const string Sp_Select_NoteSearchByAuthorId = "Sp_Select_NoteSearchByAuthorId";
    }
}
