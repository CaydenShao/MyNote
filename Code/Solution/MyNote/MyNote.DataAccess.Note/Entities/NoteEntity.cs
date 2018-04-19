using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.Entities
{
    public class NoteEntity
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string Remark { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastBrowsedTime { get; set; }

        public bool IsShared { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedTime { get; set; }
    }
}
