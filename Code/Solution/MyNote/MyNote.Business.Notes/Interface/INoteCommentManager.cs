using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Interface
{
    public interface INoteCommentManager
    {
        ManagerResult<NoteComment> AddNoteComment(NoteComment noteComment);

        ManagerResult<NoteComment> GetNoteCommentById(int id);

        ManagerResult<List<NoteComment>> GetNoteCommentsByNoteId(int noteId);
    }
}
