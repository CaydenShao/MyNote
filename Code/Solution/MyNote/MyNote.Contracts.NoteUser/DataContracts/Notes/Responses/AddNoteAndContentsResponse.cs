﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes.Responses
{
    public class AddNoteAndContentsResponse
    {
        public Note Note { get; set; }

        public List<NoteContent> NoteContents { get; set; }
    }
}
