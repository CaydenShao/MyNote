using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes.Responses
{
    public class SearchNotesResponse
    {
        public List<Note> Notes { get; set; }

        public int TotalRows { get; set; }
    }
}
