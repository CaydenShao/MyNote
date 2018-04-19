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
    public class NoteCommentDAL
    {
        private static NoteCommentDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private NoteCommentDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static NoteCommentDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteCommentDAL();
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

        public NoteComment AddNoteComment(NoteComment noteComment)
        {
            NoteCommentEntity entity = noteComment.ToEntity();
            noteComment.CreateTime = DateTime.Now;
            noteComment.DeletedTime = DateTime.Now;
            noteComment.IsDeleted = false;
            this.dbContext.NoteComments.Add(entity);
            this.dbContext.SaveChanges();
            return entity.ToModel();
        }

        public NoteComment GetNoteCommentById(int id)
        {
            NoteCommentEntity entity = this.dbContext.NoteComments.FirstOrDefault(nc => nc.Id == id);
            return entity == null ? null : entity.ToModel();
        }

        public List<NoteComment> GetNoteCommentsByNoteId(int id)
        {
            return this.dbContext.NoteComments
                .Where(nc => nc.NoteId == id)
                .Select(nc => nc.ToModel())
                .ToList();
        }

        #endregion
    }
}
