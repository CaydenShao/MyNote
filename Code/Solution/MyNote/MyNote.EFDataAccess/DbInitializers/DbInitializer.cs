using MyNote.EFDataAccess.DAL;
using MyNote.EFDataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.DbInitializers
{
    public static class DbInitializer
    {
        public static void SetMyNoteDbInitializerMode(DbInitializerType initializerType)
        {
            if (initializerType == DbInitializerType.Null)
            {
                Database.SetInitializer<MyNoteContext>(null);
            }
            else if (initializerType == DbInitializerType.CreateDatabaseIfNotExists)
            {
                Database.SetInitializer(new CreateDatabaseIfNotExistsInitializer());
            }
            else if (initializerType == DbInitializerType.DropCreateDatabaseAlways)
            {
                Database.SetInitializer(new DropCreateDatabaseAlwaysInitializer());
            }
            else if (initializerType == DbInitializerType.DropCreateDatabaseIfModelChanges)
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChangesInitializer());
            }
            else if (initializerType == DbInitializerType.MigrateDatabaseToLatestVersion)
            {
                throw new NotImplementedException("指定的数据库初始化器尚未实现,DbInitializerType：" + initializerType.ToString());
            }
            else
            {
                throw new NotImplementedException("指定的数据库初始化器尚未实现,DbInitializerType：" + initializerType.ToString());
            }
        }
    }
}
