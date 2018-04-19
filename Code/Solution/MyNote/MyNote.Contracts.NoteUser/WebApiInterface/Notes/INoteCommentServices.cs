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
    public interface INoteCommentServices
    {
        Response<NoteComment> AddNoteComment(TokenRequest<AddNoteCommentRequest> request);

        Response<NoteComment> GetNoteCommentById(TokenRequest<GetNoteCommentByIdRequest> request);

        Response<List<NoteComment>> GetNoteCommentsByNoteId(TokenRequest<GetNoteCommentsByNoteIdRequest> request);
    }
}
