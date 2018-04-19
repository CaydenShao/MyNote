using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.EFDataAccess.Entities.NoteUser;
using MyNote.EFDataAccess.Extensions.NoteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.DAL.NoteUser
{
    public class VerificationDAL
    {
        private static VerificationDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private VerificationDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static VerificationDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new VerificationDAL();
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

        public Verification AddOrUpdateVerification(Verification verification)
        {
            VerificationEntity entity = this.dbContext.Verifications.FirstOrDefault(v => v.PhoneNumber == verification.PhoneNumber);

            if (entity == null)
            {
                entity = verification.ToEntity();
                this.dbContext.Verifications.Add(entity);
                this.dbContext.SaveChanges();
                return entity.ToModel();
            }
            else
            {
                entity.StartTime = DateTime.Now;
                entity.Code = verification.Code;
                this.dbContext.SaveChanges();
                return entity.ToModel();
            }
        }

        public Verification GetVerificationById(int id)
        {
            VerificationEntity entity = this.dbContext.Verifications.FirstOrDefault(v => v.Id == id);
            return entity == null ? null : entity.ToModel();
        }

        public Verification GetVerificationByPhoneNumber(string phoneNumber)
        {
            VerificationEntity entity = this.dbContext.Verifications.FirstOrDefault(v => v.PhoneNumber == phoneNumber);
            return entity == null ? null : entity.ToModel();
        }

        #endregion
    }
}
