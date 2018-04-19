using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Interface
{
    public interface INoteApprovedRecordManager
    {
        ManagerResult<NoteApprovedRecord> NoteGetApproved(int noteId, int userId);

        ManagerResult<List<NoteApprovedRecord>> GetNoteApprovedRecordsByUserId(int id);

        ManagerResult<List<NoteApprovedRecord>> GetNoteApprovedRecordsByNoteId(int noteId);

        ManagerResult<NoteApprovedRecord> GetNoteApprovedRecordByNoteIdAndUserId(int noteId, int userId);
    }
}
