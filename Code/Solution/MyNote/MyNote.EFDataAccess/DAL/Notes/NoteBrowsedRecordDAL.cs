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
    public class NoteBrowsedRecordDAL
    {
        private static NoteBrowsedRecordDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private NoteBrowsedRecordDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static NoteBrowsedRecordDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteBrowsedRecordDAL();
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

        public NoteBrowsedRecord AddNoteBrowsedRecord(int noteId, int userId)
        {
            NoteBrowsedRecordEntity entity = new NoteBrowsedRecordEntity()
            {
                BrowsedTime = DateTime.Now,
                NoteId = noteId,
                UserId = userId,
            };

            this.dbContext.NoteBrowsedRecords.Add(entity);
            this.dbContext.SaveChanges();
            return entity.ToModel();
        }

        public List<NoteBrowsedRecord> GetNoteBrowsedRecordsByNoteId(int noteId)
        {
            return this.dbContext.NoteBrowsedRecords
                .Where(nb => nb.NoteId == noteId)
                .Select(nb => nb.ToModel())
                .ToList();
        }

        public List<NoteBrowsedRecord> GetNoteBrowsedRecordsByUserId(int userId)
        {
            return this.dbContext.NoteBrowsedRecords
                .Where(nb => nb.UserId == userId)
                .Select(nb => nb.ToModel())
                .ToList();
        }

        #endregion
    }
}
