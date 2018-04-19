using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.Notes.Requests;
using MyNote.Contracts.DataContracts.Notes.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.WebApiInterface.Notes
{
    public interface INoteServices
    {
        Response<Note> AddNote(TokenRequest<AddNoteRequest> request);

        Response<AddNoteAndContentsResponse> AddNoteAndContents(TokenRequest<AddNoteAndContentsRequest> request);

        Response<Note> GetNoteById(TokenRequest<GetNoteByIdRequest> request);

        Response<List<Note>> GetNotesByAuthorId(TokenRequest<GetNotesByAuthorIdRequest> request);

        Response<NoteBrowsedRecord> NoteGetBrowsed(TokenRequest<NoteGetBrowsedRequest> request);

        Response<SearchNotesResponse> SearchNotesByAuthorId(TokenRequest<SearchNotesByAuthorIdRequest> request);

        Response<SearchNotesResponse> SearchNotesByRemark(TokenRequest<SearchNotesByKeyStrRequest> request);

        Response<SearchNotesResponse> SearchNotesByRemarkAndAuthorId(TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest> request);

        Response<SearchNotesResponse> SearchNotesByTitle(TokenRequest<SearchNotesByKeyStrRequest> request);

        Response<SearchNotesResponse> SearchNotesByTitleAndAuthorId(TokenRequest<SearchNotesByKeyStrAndAuthorIdRequest> request);

        Response<SearchNotesResponse> SearchNotesByTimeSpan(TokenRequest<SearchNotesByTimeSpanRequest> request);

        Response<SearchNotesResponse> SearchNotesByTimeSpanAndAuthorId(TokenRequest<SearchNotesByTimeSpanAndAuthorIdRequest> request);
    }
}
