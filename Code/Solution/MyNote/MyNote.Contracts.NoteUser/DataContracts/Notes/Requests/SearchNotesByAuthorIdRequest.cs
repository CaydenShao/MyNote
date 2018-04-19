using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes.Requests
{
    public class SearchNotesByAuthorIdRequest
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int AuthorId { get; set; }
    }
}
