using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.NoteUser
{
    public class User : DataContractBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastLoginTime { get; set; }

        public string LastLoginAddress { get; set; }

        public string Token { get; set; }

        public string VerificationCode { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name)
                || !ArgumentVerify.IsMobilePhoneNumber(PhoneNumber)
                || string.IsNullOrEmpty(Email)
                || string.IsNullOrEmpty(ProfilePicture)
                || !ArgumentVerify.IsValidSqlDateTime(CreateTime)
                || !ArgumentVerify.IsValidSqlDateTime(LastLoginTime)
                || !ArgumentVerify.IsIPv4(LastLoginAddress)
                || string.IsNullOrEmpty(Token))
            {
                throw new ArgumentException();
            }
        }
    }
}
