using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Interface
{
    public interface INoteCommentContentManager
    {
        ManagerResult<NoteCommentContent> AddNoteCommentContent(NoteCommentContent commentContent);

        ManagerResult<NoteCommentContent> GetNoteCommentContentById(int id);

        ManagerResult<List<NoteCommentContent>> GetNoteCommentContentsByCommentId(int commentId);
    }
}
