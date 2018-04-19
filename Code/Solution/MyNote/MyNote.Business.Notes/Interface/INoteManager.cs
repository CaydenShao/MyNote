using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Interface
{
    public interface INoteManager
    {
        ManagerResult<Note> AddNote(Note note);

        ManagerResult<bool> AddNoteAndContents(Note note, List<NoteContent> noteContents);

        ManagerResult<Note> GetNoteById(int id);

        ManagerResult<List<Note>> GetNotesByAuthorId(int id);

        ManagerResult<NoteBrowsedRecord> NoteGetBrowsed(int noteId, int userId);

        ManagerResult<List<Note>> SearchNotesByAuthorId(int pageSize, int pageIndex, int authorId, out int totalRows);

        ManagerResult<List<Note>> SearchNotesByRemark(int pageSize, int pageIndex, string searchStr, out int totalRows);

        ManagerResult<List<Note>> SearchNotesByRemarkAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows);

        ManagerResult<List<Note>> SearchNotesByTitle(int pageSize, int pageIndex, string searchStr, out int totalRows);

        ManagerResult<List<Note>> SearchNotesByTitleAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows);

        ManagerResult<List<Note>> SearchNotesByTimeSpan(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, out int totalRows);

        ManagerResult<List<Note>> SearchNotesByTimeSpanAndAuthorId(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, int authorId, out int totalRows);
    }
}
