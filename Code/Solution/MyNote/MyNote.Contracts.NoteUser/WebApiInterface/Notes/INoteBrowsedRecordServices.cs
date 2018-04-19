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
    public interface INoteBrowsedRecordServices
    {
        Response<NoteBrowsedRecord> AddNoteBrowsedRecord(TokenRequest<AddNoteBrowsedRecordRequest> request);

        Response<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByNoteId(TokenRequest<GetNoteBrowsedRecordsByNoteIdRequest> request);

        Response<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByUserId(TokenRequest<GetNoteBrowsedRecordsByUserIdRequest> request);
    }
}
