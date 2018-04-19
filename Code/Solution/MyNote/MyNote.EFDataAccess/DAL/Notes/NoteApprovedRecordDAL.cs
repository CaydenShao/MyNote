using MyNote.Contracts.DataContracts.Notes;
using MyNote.EFDataAccess.Entities.Notes;
using MyNote.EFDataAccess.Extensions.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.DAL.Notes
{
    public class NoteApprovedRecordDAL
    {
        private static NoteApprovedRecordDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private NoteApprovedRecordDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static NoteApprovedRecordDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteApprovedRecordDAL();
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

        public NoteApprovedRecord AddOrUpdateToNotCancel(int noteId, int userId)
        {
            NoteApprovedRecordEntity entity = this.dbContext.NoteApprovedRecords
                .FirstOrDefault(na => na.NoteId == noteId && na.UserId == userId);

            if (entity == null)
            {
                entity = new NoteApprovedRecordEntity()
                {
                    ApprovedTime = DateTime.Now,
                    CanceledTime = DateTime.Now,
                    IsCanceled = false,
                    NoteId = noteId,
                    UserId = userId,
                };

                this.dbContext.NoteApprovedRecords.Add(entity);
                this.dbContext.SaveChanges();
                return entity.ToModel();
            }
            else
            {
                entity.IsCanceled = false;
                this.dbContext.SaveChanges();
                return entity.ToModel();
            }
        }

        public NoteApprovedRecord GetCanceled(int noteId, int userId)
        {
            NoteApprovedRecordEntity entity = this.dbContext.NoteApprovedRecords
                .FirstOrDefault(na => na.NoteId == noteId && na.UserId == userId);

            if (entity == null)
            {
                return null;
            }
            else
            {
                entity.IsCanceled = true;
                this.dbContext.SaveChanges();
                return entity.ToModel();
            }
        }

        public List<NoteApprovedRecord> GetNoteApprovedRecordsByNoteId(int noteId)
        {
            return this.dbContext.NoteApprovedRecords
                .Where(na => na.NoteId == noteId)
                .Select(na => na.ToModel())
                .ToList();
        }

        public List<NoteApprovedRecord> GetNoteApprovedRecordsByUserId(int userId)
        {
            return this.dbContext.NoteApprovedRecords
                .Where(na => na.UserId == userId)
                .Select(na => na.ToModel())
                .ToList();
        }

        public NoteApprovedRecord GetNoteApprovedRecordByNoteIdAndUserId(int noteId, int userId)
        {
            NoteApprovedRecordEntity entity = this.dbContext.NoteApprovedRecords
                .FirstOrDefault(na => na.NoteId == noteId && na.UserId == userId);
            return entity == null ? null : entity.ToModel();
        }

        #endregion
    }
}
