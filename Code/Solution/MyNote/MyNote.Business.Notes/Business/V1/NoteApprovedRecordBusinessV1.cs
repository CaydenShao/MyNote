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
    public class NoteApprovedRecordBusinessV1 : INoteApprovedRecordManager
    {
        public ManagerResult<NoteApprovedRecord> NoteGetApproved(int noteId, int userId)
        {
            ManagerResult<NoteApprovedRecord> result = new ManagerResult<NoteApprovedRecord>();

            try
            {
                result.ResultData = NoteApprovedRecordDAL.Instance.AddOrUpdateToNotCancel(noteId, userId);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "数据更新失败！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<List<NoteApprovedRecord>> GetNoteApprovedRecordsByUserId(int userId)
        {
            ManagerResult<List<NoteApprovedRecord>> result = new ManagerResult<List<NoteApprovedRecord>>();

            try
            {
                result.ResultData = NoteApprovedRecordDAL.Instance.GetNoteApprovedRecordsByUserId(userId);

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

        public ManagerResult<List<NoteApprovedRecord>> GetNoteApprovedRecordsByNoteId(int noteId)
        {
            ManagerResult<List<NoteApprovedRecord>> result = new ManagerResult<List<NoteApprovedRecord>>();

            try
            {
                result.ResultData = NoteApprovedRecordDAL.Instance.GetNoteApprovedRecordsByNoteId(noteId);

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

        public ManagerResult<NoteApprovedRecord> GetNoteApprovedRecordByNoteIdAndUserId(int noteId, int userId)
        {
            ManagerResult<NoteApprovedRecord> result = new ManagerResult<NoteApprovedRecord>();

            try
            {
                result.ResultData = NoteApprovedRecordDAL.Instance.GetNoteApprovedRecordByNoteIdAndUserId(noteId, userId);

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
