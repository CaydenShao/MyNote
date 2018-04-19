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
    public class CommentContentDAL
    {
        private static CommentContentDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private CommentContentDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static CommentContentDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CommentContentDAL();
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

        public NoteCommentContent AddCommentContent(NoteCommentContent commentContent)
        {
            CommentContentEntity entity = commentContent.ToEntity();
            this.dbContext.CommentContents.Add(entity);
            this.dbContext.SaveChanges();
            return entity.ToModel();
        }

        public NoteCommentContent GetCommentContentById(int id)
        {
            CommentContentEntity entity = this.dbContext.CommentContents.FirstOrDefault(cc => cc.Id == id);
            return entity == null ? null : entity.ToModel();
        }

        public List<NoteCommentContent> GetCommentContentByCommentId(int commentId)
        {
            return this.dbContext.CommentContents
                .Where(cc => cc.CommentId == commentId)
                .Select(cc => cc.ToModel())
                .ToList();
        }

        #endregion
    }
}
