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
    public class NoteManager : ManagerBase, INoteManager
    {
        #region Constructors

        public NoteManager(string version)
            : base(version)
        {

        }

        #endregion

        #region Public methods

        public ManagerResult<Note> AddNote(Note note)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.AddNote(note);
        }

        public ManagerResult<bool> AddNoteAndContents(Note note, List<NoteContent> noteContents)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.AddNoteAndContents(note, noteContents);
        }

        public ManagerResult<Note> GetNoteById(int id)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteById(id);
        }

        public ManagerResult<List<Note>> GetNotesByAuthorId(int id)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.GetNotesByAuthorId(id);
        }

        public ManagerResult<NoteBrowsedRecord> NoteGetBrowsed(int noteId, int userId)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.NoteGetBrowsed(noteId, userId);
        }

        public ManagerResult<List<Note>> SearchNotesByAuthorId(int pageSize, int pageIndex, int authorId, out int totalRows)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.SearchNotesByAuthorId(pageSize, pageIndex, authorId, out totalRows);
        }

        public ManagerResult<List<Note>> SearchNotesByRemark(int pageSize, int pageIndex, string searchStr, out int totalRows)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.SearchNotesByRemark(pageSize, pageIndex, searchStr, out totalRows);
        }

        public ManagerResult<List<Note>> SearchNotesByRemarkAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.SearchNotesByRemarkAndAuthorId(pageSize, pageIndex, searchStr, authorId, out totalRows);
        }

        public ManagerResult<List<Note>> SearchNotesByTitle(int pageSize, int pageIndex, string searchStr, out int totalRows)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.SearchNotesByTitle(pageSize, pageIndex, searchStr, out totalRows);
        }

        public ManagerResult<List<Note>> SearchNotesByTitleAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.SearchNotesByTitleAndAuthorId(pageSize, pageIndex, searchStr, authorId, out totalRows);
        }

        public ManagerResult<List<Note>> SearchNotesByTimeSpan(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, out int totalRows)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.SearchNotesByTimeSpan(pageSize, pageIndex, startTime, endTime, out totalRows);
        }

        public ManagerResult<List<Note>> SearchNotesByTimeSpanAndAuthorId(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, int authorId, out int totalRows)
        {
            INoteManager business = NoteBusinessFactory.Instance.Create(this.Version);
            return business.SearchNotesByTimeSpanAndAuthorId(pageSize, pageIndex, startTime, endTime, authorId, out totalRows);
        }

        #endregion
    }
}
