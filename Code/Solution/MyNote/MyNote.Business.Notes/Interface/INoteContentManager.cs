using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Interface
{
    public interface INoteContentManager
    {
        ManagerResult<List<NoteContent>> GetNoteContentsByNoteId(int noteId);

        ManagerResult<NoteContent> GetNoteContentById(int id);

        ManagerResult<NoteContent> AddContent(NoteContent noteContent);
    }
}
