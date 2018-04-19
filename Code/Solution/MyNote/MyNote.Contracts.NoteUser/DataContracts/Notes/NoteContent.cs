using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes
{
    public class NoteContent : DataContractBase
    {
        public int Id { get; set; }

        public int NoteId { get; set; }

        public int Type { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedTime { get; set; }

        public override void Validate()
        {
            if (NoteId <= 0
                || Type < 0
                || string.IsNullOrEmpty(Content)
                || !ArgumentVerify.IsValidSqlDateTime(CreateTime)
                || !ArgumentVerify.IsValidSqlDateTime(DeletedTime))
            {
                throw new ArgumentException();
            }
        }
    }
}
