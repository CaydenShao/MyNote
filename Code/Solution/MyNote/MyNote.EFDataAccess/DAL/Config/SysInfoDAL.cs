using MyNote.Contracts.DataContracts.Config;
using MyNote.EFDataAccess.Entities.Config;
using MyNote.EFDataAccess.Extensions.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.DAL.Config
{
    public class SysInfoDAL
    {
        private static SysInfoDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private SysInfoDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static SysInfoDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SysInfoDAL();
                        }
                    }
                }

                return instance;
            }
        }

        public static object SyncRoot
        {
            get
            {
                return syncRoot;
            }
        }

        private MyNoteContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        #endregion

        #region Public methods

        public SysInfo AddSysInfo(SysInfo sysInfo)
        {
            SysInfoEntity entity = sysInfo.ToEntity();
            this.dbContext.SysInfos.Add(entity);
            this.dbContext.SaveChanges();
            return entity.ToModel();
        }

        public SysInfo GetSysInfoById(int id)
        {
            SysInfoEntity entity = this.dbContext.SysInfos.FirstOrDefault(si => si.Id == id);
            return entity == null ? null : entity.ToModel();
        }

        public SysInfo GetSysInfoByName(string name)
        {
            SysInfoEntity entity = this.dbContext.SysInfos.FirstOrDefault(si => si.Name == name);
            return entity == null ? null : entity.ToModel();
        }

        #endregion
    }
}
