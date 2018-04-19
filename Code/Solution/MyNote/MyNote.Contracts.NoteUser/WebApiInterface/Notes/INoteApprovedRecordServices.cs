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
    public interface INoteApprovedRecordServices
    {
        Response<NoteApprovedRecord> ApproveNote(TokenRequest<ApproveNoteRequest> request);

        Response<List<NoteApprovedRecord>> GetNoteApprovedRecordsByUserId(TokenRequest<GetNoteApprovedRecordsByUserIdRequest> request);

        Response<List<NoteApprovedRecord>> GetNoteApprovedRecordsByNoteId(TokenRequest<GetNoteApprovedRecordsByNoteIdRequest> request);

        Response<NoteApprovedRecord> GetNoteApprovedRecordsByNoteIdAndUserId(TokenRequest<GetNoteApprovedRecordsByNoteIdAndUserIdRequest> request);
    }
}
