using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.Notes.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.WebApiInterface.Notes
{
    public interface INoteCommentContentServices
    {
        Response<NoteCommentContent> AddNoteCommentContent(TokenRequest<AddNoteCommentContentRequest> request);

        Response<NoteCommentContent> GetNoteCommentContentById(TokenRequest<GetNoteCommentContentByIdRequest> request);

        Response<List<NoteCommentContent>> GetNoteCommentContentsByCommentId(TokenRequest<GetNoteCommentContentsByCommentIdRequest> request);
    }
}
