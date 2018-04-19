using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes
{
    public class NoteApprovedRecord : DataContractBase
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int NoteId { get; set; }

        public DateTime ApprovedTime { get; set; }

        public bool IsCanceled { get; set; }

        public DateTime CanceledTime { get; set; }

        public override void Validate()
        {
            if (UserId <= 0
                || NoteId <= 0
                || !ArgumentVerify.IsValidSqlDateTime(ApprovedTime)
                || !ArgumentVerify.IsValidSqlDateTime(CanceledTime))
            {
                throw new ArgumentException();
            }
        }
    }
}
