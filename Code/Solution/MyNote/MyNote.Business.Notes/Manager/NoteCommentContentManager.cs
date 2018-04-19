using MyNote.Business.Common;
using MyNote.Business.Common.Bases;
using MyNote.Business.Notes.Business;
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

namespace MyNote.Business.Notes.Manager
{
    public class NoteCommentContentManager : ManagerBase, INoteCommentContentManager
    {
        #region Constructors

        public NoteCommentContentManager(string version)
            : base(version)
        {

        }

        #endregion

        #region Public methods

        public ManagerResult<NoteCommentContent> AddNoteCommentContent(NoteCommentContent commentContent)
        {
            INoteCommentContentManager business = NoteCommentContentBusinessFactory.Instance.Create(this.Version);
            return business.AddNoteCommentContent(commentContent);
        }

        public ManagerResult<NoteCommentContent> GetNoteCommentContentById(int id)
        {
            INoteCommentContentManager business = NoteCommentContentBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteCommentContentById(id);
        }

        public ManagerResult<List<NoteCommentContent>> GetNoteCommentContentsByCommentId(int commentId)
        {
            INoteCommentContentManager business = NoteCommentContentBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteCommentContentsByCommentId(commentId);
        }

        #endregion
    }
}
