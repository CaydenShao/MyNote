﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes.Requests
{
    public class SearchNotesByTimeSpanAndAuthorIdRequest
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int AuthorId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
