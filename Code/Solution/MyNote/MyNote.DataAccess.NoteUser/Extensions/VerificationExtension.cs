using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.DataAccess.NoteUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.NoteUser.Extensions
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
