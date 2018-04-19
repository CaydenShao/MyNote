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
    public class FtpConfigDAL
    {
        private static FtpConfigDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private FtpConfigDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static FtpConfigDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new FtpConfigDAL();
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

        public FtpConfig AddFtpConfig(FtpConfig ftpConfig)
        {
            FtpConfigEntity entity = ftpConfig.ToEntity();
            this.dbContext.FtpConfigs.Add(entity);
            this.dbContext.SaveChanges();
            return entity.ToModel();
        }

        public FtpConfig GetFtpConfigById(int id)
        {
            FtpConfigEntity entity = this.dbContext.FtpConfigs.FirstOrDefault(fc => fc.Id == id);
            return entity == null ? null : entity.ToModel();
        }

        public FtpConfig GetFtpConfigByName(string name)
        {
            FtpConfigEntity entity = this.dbContext.FtpConfigs.FirstOrDefault(fc => fc.Name == name);
            return entity == null ? null : entity.ToModel();
        }

        #endregion
    }
}
