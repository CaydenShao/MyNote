using MyNote.Business.Common;
using MyNote.Business.Notes.Interface;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.DataAccess.Notes.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Business.V1
{
    public class NoteCommentBusinessV1 : INoteCommentManager
    {
        public ManagerResult<NoteComment> AddNoteComment(NoteComment noteComment)
        {
            ManagerResult<NoteComment> result = new ManagerResult<NoteComment>();

            try
            {
                result.ResultData = NoteCommentDAL.Instance.AddNoteComment(noteComment);

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

        public ManagerResult<NoteComment> GetNoteCommentById(int id)
        {
            ManagerResult<NoteComment> result = new ManagerResult<NoteComment>();

            try
            {
                result.ResultData = NoteCommentDAL.Instance.GetNoteCommentById(id);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "对应数据不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<List<NoteComment>> GetNoteCommentsByNoteId(int noteId)
        {
            ManagerResult<List<NoteComment>> result = new ManagerResult<List<NoteComment>>();

            try
            {
                result.ResultData = NoteCommentDAL.Instance.GetNoteCommentsByNoteId(noteId);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "对应数据不存在！";
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
