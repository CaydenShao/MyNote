using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.EFDataAccess.Entities.NoteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Extensions.NoteUser
{
    public static class UserExtension
    {
        public static UserEntity ToEntity(this User user)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                ProfilePicture = user.ProfilePicture,
                CreateTime = user.CreateTime,
                LastLoginTime = user.LastLoginTime,
                LastLoginAddress = user.LastLoginAddress,
                Token = user.Token,
                VerificationCode = user.VerificationCode
            };
        }

        public static User ToModel(this UserEntity user)
        {
            return new User()
            {
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                ProfilePicture = user.ProfilePicture,
                //HashCode = user.HashCode,
                //Salt = user.Salt,
                CreateTime = user.CreateTime,
                LastLoginTime = user.LastLoginTime,
                LastLoginAddress = user.LastLoginAddress,
                Token = user.Token,
                VerificationCode = user.VerificationCode
            };
        }
    }
}
