using MyNote.Business.Common;
using MyNote.Business.Notes.Interface;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.EFDataAccess.DAL.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Business.V2
{
    public class NoteBusinessV2 : INoteManager
    {
        public ManagerResult<Note> AddNote(Note note)
        {
            ManagerResult<Note> result = new ManagerResult<Note>();

            try
            {
                result.ResultData = NoteDAL.Instance.AddNote(note);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "添加失败！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<bool> AddNoteAndContents(Note note, List<NoteContent> noteContents)
        {
            ManagerResult<bool> result = new ManagerResult<bool>();
            result.ResultData = false;

            try
            {
                result.ResultData = NoteDAL.Instance.AddNoteAndContents(note, noteContents);

                if (!result.ResultData)
                {
                    result.Code = 1;
                    result.Description = "添加失败！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<Note> GetNoteById(int id)
        {
            ManagerResult<Note> result = new ManagerResult<Note>();

            try
            {
                result.ResultData = NoteDAL.Instance.GetNoteById(id);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "对应Note不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<List<Note>> GetNotesByAuthorId(int id)
        {
            ManagerResult<List<Note>> result = new ManagerResult<List<Note>>();

            try
            {
                result.ResultData = NoteDAL.Instance.GetNoteByAuthorId(id);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "对应Note不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<NoteBrowsedRecord> NoteGetBrowsed(int noteId, int userId)
        {
            ManagerResult<NoteBrowsedRecord> result = new ManagerResult<NoteBrowsedRecord>();

            try
            {
                result.ResultData = NoteDAL.Instance.NoteGetBrowsed(noteId, userId);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<List<Note>> SearchNotesByAuthorId(int pageSize, int pageIndex, int authorId, out int totalRows)
        {
            ManagerResult<List<Note>> result = new ManagerResult<List<Note>>();
            int rows = 0;

            try
            {
                result.ResultData = NoteDAL.Instance.SearchByAuthorId(pageSize, pageIndex, authorId, out rows);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            totalRows = rows;
            return result;
        }

        public ManagerResult<List<Note>> SearchNotesByRemark(int pageSize, int pageIndex, string searchStr, out int totalRows)
        {
            ManagerResult<List<Note>> result = new ManagerResult<List<Note>>();
            int rows = 0;

            try
            {
                result.ResultData = NoteDAL.Instance.SearchByRemark(pageSize, pageIndex, searchStr, out rows);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            totalRows = rows;
            return result;
        }

        public ManagerResult<List<Note>> SearchNotesByRemarkAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows)
        {
            ManagerResult<List<Note>> result = new ManagerResult<List<Note>>();
            int rows = 0;

            try
            {
                result.ResultData = NoteDAL.Instance.SearchByRemarkAndAuthorId(pageSize, pageIndex, searchStr, authorId, out rows);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            totalRows = rows;
            return result;
        }

        public ManagerResult<List<Note>> SearchNotesByTitle(int pageSize, int pageIndex, string searchStr, out int totalRows)
        {
            ManagerResult<List<Note>> result = new ManagerResult<List<Note>>();
            int rows = 0;

            try
            {
                result.ResultData = NoteDAL.Instance.SearchByTitle(pageSize, pageIndex, searchStr, out rows);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            totalRows = rows;
            return result;
        }

        public ManagerResult<List<Note>> SearchNotesByTitleAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows)
        {
            ManagerResult<List<Note>> result = new ManagerResult<List<Note>>();
            int rows = 0;

            try
            {
                result.ResultData = NoteDAL.Instance.SearchByTitleAndAuthorId(pageSize, pageIndex, searchStr, authorId, out rows);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            totalRows = rows;
            return result;
        }

        public ManagerResult<List<Note>> SearchNotesByTimeSpan(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, out int totalRows)
        {
            ManagerResult<List<Note>> result = new ManagerResult<List<Note>>();
            int rows = 0;

            try
            {
                result.ResultData = NoteDAL.Instance.SearchByTimeSpan(pageSize, pageIndex, startTime, endTime, out rows);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            totalRows = rows;
            return result;
        }

        public ManagerResult<List<Note>> SearchNotesByTimeSpanAndAuthorId(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, int authorId, out int totalRows)
        {
            ManagerResult<List<Note>> result = new ManagerResult<List<Note>>();
            int rows = 0;

            try
            {
                result.ResultData = NoteDAL.Instance.SearchByTimeSpanAndAuthorId(pageSize, pageIndex, startTime, endTime, authorId, out rows);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            totalRows = rows;
            return result;
        }
    }
}
