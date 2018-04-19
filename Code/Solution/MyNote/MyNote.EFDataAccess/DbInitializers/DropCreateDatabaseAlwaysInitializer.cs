using MyNote.EFDataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.DbInitializers
{
    internal class DropCreateDatabaseAlwaysInitializer : DropCreateDatabaseAlways<MyNoteContext>
    {
        protected override void Seed(MyNoteContext context)
        {
            base.Seed(context);
        }
    }
}
