using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.NoteUser.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        public string HashCode { get; set; }

        public string Salt { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastLoginTime { get; set; }

        public string LastLoginAddress { get; set; }

        public string Token { get; set; }

        public string VerificationCode { get; set; }
    }
}
