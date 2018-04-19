using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Enums
{
    public enum DbInitializerType
    {
        Null,
        CreateDatabaseIfNotExists,
        DropCreateDatabaseIfModelChanges,
        DropCreateDatabaseAlways,
        MigrateDatabaseToLatestVersion // EF4.3才可用
    }
}
