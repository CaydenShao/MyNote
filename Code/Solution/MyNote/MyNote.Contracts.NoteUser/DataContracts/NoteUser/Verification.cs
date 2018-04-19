using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.NoteUser
{
    public class Verification : DataContractBase
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime StartTime { get; set; }

        public string Code { get; set; }

        public override void Validate()
        {
            if (!ArgumentVerify.IsMobilePhoneNumber(PhoneNumber)
                || !ArgumentVerify.IsValidSqlDateTime(StartTime)
                || string.IsNullOrEmpty(Code))
            {
                throw new ArgumentException();
            }
        }
    }
}
