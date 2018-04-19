using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes.Requests
{
    public class NoteGetBrowsedRequest
    {
        public int NoteId { get; set; }

        public int UserId { get; set; }
    }
}
