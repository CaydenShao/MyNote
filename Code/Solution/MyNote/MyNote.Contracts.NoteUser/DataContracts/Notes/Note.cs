using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Notes
{
    public class Note : DataContractBase
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string Remark { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastBrowsedTime { get; set; }

        public int BrowsedTimes { get; set; }

        public int ApprovedTimes { get; set; }

        public int CommentCount{ get; set; }

        public bool IsShared { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedTime { get; set; }

        public override void Validate()
        {
            if (AuthorId <= 0
                || string.IsNullOrEmpty(Remark)
                || !ArgumentVerify.IsValidSqlDateTime(CreateTime)
                || !ArgumentVerify.IsValidSqlDateTime(LastBrowsedTime)
                || BrowsedTimes < 0
                || ApprovedTimes < 0
                || !ArgumentVerify.IsValidSqlDateTime(DeletedTime))
            {
                throw new ArgumentException();
            }
        }
    }
}
