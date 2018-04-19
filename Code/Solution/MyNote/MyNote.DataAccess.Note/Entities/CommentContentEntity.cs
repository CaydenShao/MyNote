using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.Entities
{
    public class CommentContentEntity
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public int Type { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
