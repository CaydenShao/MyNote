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
    public class NoteApprovedRecordManager : ManagerBase, INoteApprovedRecordManager
    {
        #region Constructors

        public NoteApprovedRecordManager(string version) 
            : base(version)
        {

        }

        #endregion

        #region Public methods

        public ManagerResult<NoteApprovedRecord> NoteGetApproved(int noteId, int userId)
        {
            INoteApprovedRecordManager business = NoteApprovedRecordBusinessFactory.Instance.Create(this.Version);
            return business.NoteGetApproved(noteId, userId);
        }

        public ManagerResult<List<NoteApprovedRecord>> GetNoteApprovedRecordsByUserId(int userId)
        {
            INoteApprovedRecordManager business = NoteApprovedRecordBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteApprovedRecordsByUserId(userId);
        }

        public ManagerResult<List<NoteApprovedRecord>> GetNoteApprovedRecordsByNoteId(int noteId)
        {
            INoteApprovedRecordManager business = NoteApprovedRecordBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteApprovedRecordsByNoteId(noteId);
        }

        public ManagerResult<NoteApprovedRecord> GetNoteApprovedRecordByNoteIdAndUserId(int noteId, int userId)
        {
            INoteApprovedRecordManager business = NoteApprovedRecordBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteApprovedRecordByNoteIdAndUserId(noteId, userId);
        }

        #endregion
    }
}
