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
    public class NoteContentManager : ManagerBase, INoteContentManager
    {
        #region Constructors

        public NoteContentManager(string version)
            : base(version)
        {

        }

        #endregion

        #region Public methods

        public ManagerResult<List<NoteContent>> GetNoteContentsByNoteId(int noteId)
        {
            INoteContentManager business = NoteContentBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteContentsByNoteId(noteId);
        }

        public ManagerResult<NoteContent> GetNoteContentById(int id)
        {
            INoteContentManager business = NoteContentBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteContentById(id);
        }

        public ManagerResult<NoteContent> AddContent(NoteContent noteContent)
        {
            INoteContentManager business = NoteContentBusinessFactory.Instance.Create(this.Version);
            return business.AddContent(noteContent);
        }

        #endregion
    }
}
