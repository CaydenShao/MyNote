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
    public class NoteBrowsedRecordBusinessV1 : INoteBrowsedRecordManager
    {
        public ManagerResult<NoteBrowsedRecord> AddNoteBrowsedRecord(int noteId, int userId)
        {
            ManagerResult<NoteBrowsedRecord> result = new ManagerResult<NoteBrowsedRecord>();

            try
            {
                result.ResultData = NoteBrowsedRecordDAL.Instance.AddNoteBrowsedRecord(noteId, userId);

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

        public ManagerResult<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByNoteId(int noteId)
        {
            ManagerResult<List<NoteBrowsedRecord>> result = new ManagerResult<List<NoteBrowsedRecord>>();

            try
            {
                result.ResultData = NoteBrowsedRecordDAL.Instance.GetNoteBrowsedRecordsByNoteId(noteId);

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

        public ManagerResult<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByUserId(int userId)
        {
            ManagerResult<List<NoteBrowsedRecord>> result = new ManagerResult<List<NoteBrowsedRecord>>();

            try
            {
                result.ResultData = NoteBrowsedRecordDAL.Instance.GetNoteBrowsedRecordsByUserId(userId);

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
    }
}
