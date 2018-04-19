using MyNote.Contracts.DataContracts.Notes;
using MyNote.EFDataAccess.Entities.Notes;
using MyNote.EFDataAccess.Extensions.Notes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.DAL.Notes
{
    public class NoteDAL
    {
        private static NoteDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private NoteDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static NoteDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteDAL();
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

        public Note AddNote(Note note)
        {
            NoteEntity entity = note.ToEntity();
            entity.CreateTime = DateTime.Now;
            entity.DeletedTime = DateTime.Now;
            entity.IsDeleted = false;
            entity.LastBrowsedTime = DateTime.Now;
            this.dbContext.Notes.Add(entity);
            this.dbContext.SaveChanges();
            return entity.ToModel();
        }

        public Note GetNoteById(int id)
        {
            NoteEntity entity = this.dbContext.Notes.FirstOrDefault(n => n.Id == id);
            return entity == null ? null : entity.ToModel();
        }

        public List<Note> GetNoteByAuthorId(int id)
        {
            List<NoteEntity> entities = this.dbContext.Notes
                .Where(n => n.AuthorId == id)
                .ToList();
            return entities
                .Select(v => v.ToModel())
                .ToList();
        }

        public bool AddNoteAndContents(Note note, List<NoteContent> noteContents)
        {
            using (DbContextTransaction tran = this.dbContext.Database.BeginTransaction())
            {
                try
                {
                    NoteEntity noteEntity = note.ToEntity();
                    noteEntity.CreateTime = DateTime.Now;
                    noteEntity.DeletedTime = DateTime.Now;
                    noteEntity.IsDeleted = false;
                    noteEntity.LastBrowsedTime = DateTime.Now;
                    this.dbContext.Notes.Add(noteEntity);
                    this.dbContext.SaveChanges();
                    noteEntity.CopyTo(note);

                    List<NoteContentEntity> noteContentEntities = new List<NoteContentEntity>();

                    foreach (NoteContent nc in noteContents)
                    {
                        NoteContentEntity entity = nc.ToEntity();
                        entity.CreateTime = DateTime.Now;
                        entity.DeletedTime = DateTime.Now;
                        entity.IsDeleted = false;
                        entity.NoteId = noteEntity.Id;
                        this.dbContext.NoteContents.Add(entity);
                        noteContentEntities.Add(entity);
                    }

                    this.dbContext.SaveChanges();
                    tran.Commit();

                    for (int i = 0; i < noteContents.Count; i++)
                    {
                        noteContentEntities[i].CopyTo(noteContents[i]);
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }

            return true;
        }

        public NoteBrowsedRecord NoteGetBrowsed(int noteId, int userId)
        {
            NoteEntity entity = this.dbContext.Notes.FirstOrDefault(n => n.Id == noteId && n.AuthorId == userId);

            if (entity != null)
            {
                entity.LastBrowsedTime = DateTime.Now;
            }

            NoteBrowsedRecordEntity browsedRecordEntity = new NoteBrowsedRecordEntity()
            {
                BrowsedTime = DateTime.Now,
                NoteId = noteId,
                UserId = userId
            };
            this.dbContext.NoteBrowsedRecords.Add(browsedRecordEntity);
            this.dbContext.SaveChanges();
            return browsedRecordEntity.ToModel();
        }

        public List<Note> SearchByAuthorId(int pageSize, int pageIndex, int authorId, out int totalRows)
        {
            var notes = this.dbContext.Notes
                .Where(n => n.AuthorId == authorId);
            totalRows = notes.Count();
            return notes.OrderBy(n => n.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(n => n.ToModel())
                .ToList();
        }

        public List<Note> SearchByRemark(int pageSize, int pageIndex, string searchStr, out int totalRows)
        {
            var notes = this.dbContext.Notes.Where(n => n.Remark.Contains(searchStr));
            totalRows = notes.Count();
            return notes.OrderBy(n => n.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(n => n.ToModel())
                .ToList();
        }

        public List<Note> SearchByRemarkAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows)
        {
            var notes = this.dbContext.Notes.Where(n => n.AuthorId == authorId && n.Remark.Contains(searchStr));
            totalRows = notes.Count();
            return notes.OrderBy(n => n.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(n => n.ToModel())
                .ToList();
        }

        public List<Note> SearchByTitle(int pageSize, int pageIndex, string searchStr, out int totalRows)
        {
            var notes = this.dbContext.Notes.Where(n => n.Title.Contains(searchStr));
            totalRows = notes.Count();
            return notes.OrderBy(n => n.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(n => n.ToModel())
                .ToList();
        }

        public List<Note> SearchByTitleAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows)
        {
            var notes = this.dbContext.Notes.Where(n => n.AuthorId == authorId && n.Title.Contains(searchStr));
            totalRows = notes.Count();
            return notes.OrderBy(n => n.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(n => n.ToModel())
                .ToList();
        }

        public List<Note> SearchByTimeSpan(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, out int totalRows)
        {
            var notes = this.dbContext.Notes.Where(n => n.CreateTime >= startTime && n.CreateTime <= endTime);
            totalRows = notes.Count();
            return notes.OrderBy(n => n.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(n => n.ToModel())
                .ToList();
        }

        public List<Note> SearchByTimeSpanAndAuthorId(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, int authorId, out int totalRows)
        {
            var notes = this.dbContext.Notes.Where(n => n.AuthorId == authorId && n.CreateTime >= startTime && n.CreateTime <= endTime);
            totalRows = notes.Count();
            return notes.OrderBy(n => n.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(n => n.ToModel())
                .ToList();
        }

        #endregion
    }
}
