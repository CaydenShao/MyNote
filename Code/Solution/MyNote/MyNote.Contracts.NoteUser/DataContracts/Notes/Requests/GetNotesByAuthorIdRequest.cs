﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes.Requests
{
    public class GetNotesByAuthorIdRequest
    {
        public int AuthorId { get; set; }
    }
}