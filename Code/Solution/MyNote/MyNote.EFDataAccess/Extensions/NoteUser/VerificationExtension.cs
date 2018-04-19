using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.EFDataAccess.Entities.NoteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Extensions.NoteUser
{
    public static class VerificationExtension
    {
        public static Verification ToModel(this VerificationEntity verification)
        {
            return new Verification()
            {
                Id = verification.Id,
                PhoneNumber = verification.PhoneNumber,
                StartTime = verification.StartTime,
                Code = verification.Code
            };
        }

        public static VerificationEntity ToEntity(this Verification verification)
        {
            return new VerificationEntity()
            {
                Id = verification.Id,
                PhoneNumber = verification.PhoneNumber,
                StartTime = verification.StartTime,
                Code = verification.Code
            };
        }
    }
}
