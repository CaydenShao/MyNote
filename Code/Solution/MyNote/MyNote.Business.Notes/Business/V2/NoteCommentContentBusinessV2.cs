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
    public class NoteCommentContentBusinessV2 : INoteCommentContentManager
    {
        public ManagerResult<NoteCommentContent> AddNoteCommentContent(NoteCommentContent commentContent)
        {
            ManagerResult<NoteCommentContent> result = new ManagerResult<NoteCommentContent>();

            try
            {
                result.ResultData = CommentContentDAL.Instance.AddCommentContent(commentContent);

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

        public ManagerResult<NoteCommentContent> GetNoteCommentContentById(int id)
        {
            ManagerResult<NoteCommentContent> result = new ManagerResult<NoteCommentContent>();

            try
            {
                result.ResultData = CommentContentDAL.Instance.GetCommentContentById(id);

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

        public ManagerResult<List<NoteCommentContent>> GetNoteCommentContentsByCommentId(int commentId)
        {
            ManagerResult<List<NoteCommentContent>> result = new ManagerResult<List<NoteCommentContent>>();

            try
            {
                result.ResultData = CommentContentDAL.Instance.GetCommentContentByCommentId(commentId);

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
