﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.Entities
{
    public class NoteContentEntity
    {
        public int Id { get; set; }

        public int NoteId { get; set; }

        public int Type { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedTime { get; set; }
    }
}
