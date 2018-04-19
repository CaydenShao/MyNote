using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes
{
    public class NoteCommentContent : DataContractBase
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public int Type { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public override void Validate()
        {
            if (CommentId <= 0
                || Type < 0
                || CommentId <= 0
                || string.IsNullOrEmpty(Content)
                || !ArgumentVerify.IsValidSqlDateTime(CreateTime))
            {
                throw new ArgumentException();
            }
        }
    }
}
