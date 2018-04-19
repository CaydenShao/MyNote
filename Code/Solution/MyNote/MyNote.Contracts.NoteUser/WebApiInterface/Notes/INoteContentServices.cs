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
    public interface INoteContentServices
    {
        Response<List<NoteContent>> GetNoteContentsByNoteId(TokenRequest<GetNoteContentsByNoteIdRequest> request);

        Response<NoteContent> GetNoteContentsById(TokenRequest<GetNoteContentByIdRequest> request);

        Response<NoteContent> AddContent(TokenRequest<AddContentRequest> request);
    }
}
