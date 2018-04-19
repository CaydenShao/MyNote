using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.ProcedureContainer
{
    public static class SpParamsOfNote
    {
        #region Sp_Insert_Note

        /// <summary>
        /// Sp_Insert_Note的参数1：AuthorId
        /// </summary>
        public const string Sp_Insert_Note_AuthorId = "AuthorId";
        /// <summary>
        /// Sp_Insert_Note的参数2：Title
        /// </summary>
        public const string Sp_Insert_Note_Title = "Title";
        /// <summary>
        /// Sp_Insert_Note的参数3：Remark
        /// </summary>
        public const string Sp_Insert_Note_Remark = "Remark";
        /// <summary>
        /// Sp_Insert_Note的参数4：IsShared
        /// </summary>
        public const string Sp_Insert_Note_IsShared = "IsShared";

        #endregion

        #region Sp_Select_NoteById

        /// <summary>
        /// Sp_Select_NoteById的参数1：Id
        /// </summary>
        public const string Sp_Select_NoteById_Id = "Id";

        #endregion

        #region Sp_Select_NoteByAuthorId

        /// <summary>
        /// Sp_Select_NoteByAuthorId的参数1：AuthorId
        /// </summary>
        public const string Sp_Select_NoteByAuthorId_AuthorId = "AuthorId";

        #endregion

        #region Sp_Update_NoteGetBrowsed

        /// <summary>
        /// Sp_Update_NoteGetBrowsed的参数1：NoteId
        /// </summary>
        public const string Sp_Update_NoteGetBrowsed_NoteId = "NoteId";
        /// <summary>
        /// Sp_Update_NoteGetBrowsed的参数2：UserId
        /// </summary>
        public const string Sp_Update_NoteGetBrowsed_UserId = "UserId";

        #endregion

        #region Sp_Select_NoteSearchByRemark

        /// <summary>
        /// Sp_Select_NoteSearchByRemark的参数1：PageSize
        /// </summary>
        public const string Sp_Select_NoteSearchByRemark_PageSize = "PageSize";
        /// <summary>
        /// Sp_Select_NoteSearchByRemark的参数2：PageIndex
        /// </summary>
        public const string Sp_Select_NoteSearchByRemark_PageIndex = "PageIndex";
        /// <summary>
        /// Sp_Select_NoteSearchByRemark的参数3：SearchStr
        /// </summary>
        public const string Sp_Select_NoteSearchByRemark_SearchStr = "SearchStr";

        #endregion

        #region Sp_Select_NoteSearchByRemarkAndAuthorId

        /// <summary>
        /// Sp_Select_NoteSearchByRemarkAndAuthorId的参数1：PageSize
        /// </summary>
        public const string Sp_Select_NoteSearchByRemarkAndAuthorId_PageSize = "PageSize";
        /// <summary>
        /// Sp_Select_NoteSearchByRemarkAndAuthorId的参数2：PageIndex
        /// </summary>
        public const string Sp_Select_NoteSearchByRemarkAndAuthorId_PageIndex = "PageIndex";
        /// <summary>
        /// Sp_Select_NoteSearchByRemarkAndAuthorId的参数3：SearchStr
        /// </summary>
        public const string Sp_Select_NoteSearchByRemarkAndAuthorId_SearchStr = "SearchStr";
        /// <summary>
        /// Sp_Select_NoteSearchByRemarkAndAuthorId的参数4：AuthorId
        /// </summary>
        public const string Sp_Select_NoteSearchByRemarkAndAuthorId_AuthorId = "AuthorId";

        #endregion

        #region Sp_Select_NoteSearchByTitle

        /// <summary>
        /// Sp_Select_NoteSearchByTitle的参数1：PageSize
        /// </summary>
        public const string Sp_Select_NoteSearchByTitle_PageSize = "PageSize";
        /// <summary>
        /// Sp_Select_NoteSearchByTitle的参数2：PageIndex
        /// </summary>
        public const string Sp_Select_NoteSearchByTitle_PageIndex = "PageIndex";
        /// <summary>
        /// Sp_Select_NoteSearchByTitle的参数3：SearchStr
        /// </summary>
        public const string Sp_Select_NoteSearchByTitle_SearchStr = "SearchStr";

        #endregion

        #region Sp_Select_NoteSearchByTitleAndAuthorId

        /// <summary>
        /// Sp_Select_NoteSearchByTitleAndAuthorId的参数1：PageSize
        /// </summary>
        public const string Sp_Select_NoteSearchByTitleAndAuthorId_PageSize = "PageSize";
        /// <summary>
        /// Sp_Select_NoteSearchByTitleAndAuthorId的参数2：PageIndex
        /// </summary>
        public const string Sp_Select_NoteSearchByTitleAndAuthorId_PageIndex = "PageIndex";
        /// <summary>
        /// Sp_Select_NoteSearchByTitleAndAuthorId的参数3：SearchStr
        /// </summary>
        public const string Sp_Select_NoteSearchByTitleAndAuthorId_SearchStr = "SearchStr";
        /// <summary>
        /// Sp_Select_NoteSearchByTitleAndAuthorId的参数4：SearchStr
        /// </summary>
        public const string Sp_Select_NoteSearchByTitleAndAuthorId_AuthorId = "AuthorId";

        #endregion

        #region Sp_Select_NoteSearchByTimeSpan

        /// <summary>
        /// Sp_Select_NoteSearchByTimeSpan的参数1：PageSize
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpan_PageSize = "PageSize";
        /// <summary>
        /// Sp_Select_NoteSearchByTimeSpan的参数2：PageIndex
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpan_PageIndex = "PageIndex";
        /// <summary>
        /// Sp_Select_NoteSearchByTimeSpan的参数3：StartTime
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpan_StartTime = "StartTime";
        /// <summary>
        /// Sp_Select_NoteSearchByTimeSpan的参数4：EndTime
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpan_EndTime = "EndTime";

        #endregion

        #region Sp_Select_NoteSearchByTimeSpanAndAuthorId

        /// <summary>
        /// Sp_Select_NoteSearchByTimeSpanAndAuthorId的参数1：PageSize
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpanAndAuthorId_PageSize = "PageSize";
        /// <summary>
        /// Sp_Select_NoteSearchByTimeSpanAndAuthorId的参数2：PageIndex
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpanAndAuthorId_PageIndex = "PageIndex";
        /// <summary>
        /// Sp_Select_NoteSearchByTimeSpanAndAuthorId的参数3：StartTime
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpanAndAuthorId_StartTime = "StartTime";
        /// <summary>
        /// Sp_Select_NoteSearchByTimeSpanAndAuthorId的参数4：EndTime
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpanAndAuthorId_EndTime = "EndTime";
        /// <summary>
        /// Sp_Select_NoteSearchByTimeSpanAndAuthorId的参数5：AuthorId
        /// </summary>
        public const string Sp_Select_NoteSearchByTimeSpanAndAuthorId_AuthorId = "AuthorId";

        #endregion

        #region Sp_Select_NoteSearchByAuthorId

        /// <summary>
        /// Sp_Select_NoteSearchByAuthorId的参数1：PageSize
        /// </summary>
        public const string Sp_Select_NoteSearchByAuthorId_PageSize = "PageSize";
        /// <summary>
        /// Sp_Select_NoteSearchByAuthorId的参数2：PageIndex
        /// </summary>
        public const string Sp_Select_NoteSearchByAuthorId_PageIndex = "PageIndex";
        /// <summary>
        /// Sp_Select_NoteSearchByAuthorId的参数3：AuthorId
        /// </summary>
        public const string Sp_Select_NoteSearchByAuthorId_AuthorId = "AuthorId";

        #endregion
    }
}
