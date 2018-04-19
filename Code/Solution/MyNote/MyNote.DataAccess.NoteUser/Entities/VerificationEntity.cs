﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.NoteUser.Entities
{
    public class VerificationEntity
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime StartTime { get; set; }

        public string Code { get; set; }
    }
}
