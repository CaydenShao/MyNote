using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Interface
{
    public interface INoteBrowsedRecordManager
    {
        ManagerResult<NoteBrowsedRecord> AddNoteBrowsedRecord(int noteId, int userId);

        ManagerResult<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByNoteId(int noteId);

        ManagerResult<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByUserId(int userId);
    }
}
