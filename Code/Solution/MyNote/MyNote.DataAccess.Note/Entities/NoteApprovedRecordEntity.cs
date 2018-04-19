using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.Entities
{
    public class NoteApprovedRecordEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int NoteId { get; set; }

        public DateTime ApprovedTime { get; set; }

        public bool IsCanceled { get; set; }

        public DateTime CanceledTime { get; set; }
    }
}
