using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes
{
    public class NoteComment : DataContractBase
    {
        public int Id { get; set; }

        public int NoteId { get; set; }

        public int CreatorId { get; set; }

        public int CommentId { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedTime { get; set; }

        public override void Validate()
        {
            if (NoteId <= 0
                || CreatorId <= 0
                || CommentId <= 0
                || !ArgumentVerify.IsValidSqlDateTime(CreateTime)
                || !ArgumentVerify.IsValidSqlDateTime(DeletedTime))
            {
                throw new ArgumentException();
            }
        }
    }
}
