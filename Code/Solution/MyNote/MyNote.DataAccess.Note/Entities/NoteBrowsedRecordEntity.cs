using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.Entities
{
    public class NoteBrowsedRecordEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int NoteId { get; set; }

        public DateTime BrowsedTime { get; set; }
    }
}
