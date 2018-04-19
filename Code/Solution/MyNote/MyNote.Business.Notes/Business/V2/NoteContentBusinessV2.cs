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
    public class NoteContentBusinessV2 : INoteContentManager
    {
        public ManagerResult<List<NoteContent>> GetNoteContentsByNoteId(int noteId)
        {
            ManagerResult<List<NoteContent>> result = new ManagerResult<List<NoteContent>>();

            try
            {
                result.ResultData = NoteContentDAL.Instance.GetNoteCommentByNoteId(noteId);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "对应内容不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<NoteContent> GetNoteContentById(int id)
        {
            ManagerResult<NoteContent> result = new ManagerResult<NoteContent>();

            try
            {
                result.ResultData = NoteContentDAL.Instance.GetNoteCommentById(id);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "对应内容不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<NoteContent> AddContent(NoteContent noteContent)
        {
            ManagerResult<NoteContent> result = new ManagerResult<NoteContent>();

            try
            {
                result.ResultData = NoteContentDAL.Instance.AddNoteContent(noteContent);

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
    }
}
