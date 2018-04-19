using MyNote.EFDataAccess.DAL;
using MyNote.EFDataAccess.Entities.NoteUser;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.DbInitializers
{
    internal class DropCreateDatabaseIfModelChangesInitializer : DropCreateDatabaseIfModelChanges<MyNoteContext>
    {
        protected override void Seed(MyNoteContext context)
        {
            base.Seed(context);

            context.Users.Add(new UserEntity()
            {
                Name = "Cayden",
                PhoneNumber = "18827389685",
                Email = null,
                ProfilePicture = null,
                HashCode = "I4rMwnfEvlu0qnXxRiwjin7M4K6GNnmnv7HvI6BVOYA=",
                Salt = "6015062f-9295-49dd-bedd-a03044b5361d",
                CreateTime = DateTime.Now,
                LastLoginTime = DateTime.Now,
                LastLoginAddress = "192.168.2.59",
                Token = "8698808d-0bda-44b3-b798-f416a431d67d",
                VerificationCode = null
            });
        }
    }
}
