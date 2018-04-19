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
    public class NoteContentDAL
    {
        private static NoteContentDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private NoteContentDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static NoteContentDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteContentDAL();
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

        public NoteContent AddNoteContent(NoteContent noteContent)
        {
            NoteContentEntity entity = noteContent.ToEntity();
            entity.CreateTime = DateTime.Now;
            entity.DeletedTime = DateTime.Now;
            entity.IsDeleted = false;
            this.dbContext.NoteContents.Add(entity);
            this.dbContext.SaveChanges();
            return entity.ToModel();
        }

        public NoteContent GetNoteCommentById(int id)
        {
            NoteContentEntity entity = this.dbContext.NoteContents.FirstOrDefault(nc => nc.Id == id);
            return entity == null ? null : entity.ToModel();
        }

        public List<NoteContent> GetNoteCommentByNoteId(int id)
        {
            return this.dbContext.NoteContents
                .Where(nc => nc.NoteId == id)
                .ToList()
                .Select(nc => nc.ToModel())
                .ToList();
        }

        #endregion
    }
}
