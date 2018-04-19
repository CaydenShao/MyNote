using MyNote.Contracts.DataContracts.Notes;
using MyNote.EFDataAccess.Entities.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Extensions.Notes
{
    public static class NoteExtension
    {
        public static Note ToModel(this NoteEntity entity)
        {
            return new Note()
            {
                Id = entity.Id,
                AuthorId = entity.AuthorId,
                Title = entity.Title,
                Remark = entity.Remark,
                CreateTime = entity.CreateTime,
                LastBrowsedTime = entity.LastBrowsedTime,
                IsShared = entity.IsShared,
                IsDeleted = entity.IsDeleted,
                DeletedTime = entity.DeletedTime
            };
        }

        public static void CopyTo(this NoteEntity note, Note targetNote)
        {
            targetNote.Id = note.Id;
            targetNote.AuthorId = note.AuthorId;
            targetNote.Title = note.Title;
            targetNote.Remark = note.Remark;
            targetNote.CreateTime = note.CreateTime;
            targetNote.LastBrowsedTime = note.LastBrowsedTime;
            targetNote.IsShared = note.IsShared;
            targetNote.IsDeleted = note.IsDeleted;
            targetNote.DeletedTime = note.DeletedTime;
        }

        public static void CopyTo(this Note note, Note targetNote)
        {
            targetNote.Id = note.Id;
            targetNote.AuthorId = note.AuthorId;
            targetNote.Title = note.Title;
            targetNote.Remark = note.Remark;
            targetNote.CreateTime = note.CreateTime;
            targetNote.LastBrowsedTime = note.LastBrowsedTime;
            targetNote.BrowsedTimes = note.BrowsedTimes;
            targetNote.ApprovedTimes = note.ApprovedTimes;
            targetNote.CommentCount = note.CommentCount;
            targetNote.IsShared = note.IsShared;
            targetNote.IsDeleted = note.IsDeleted;
            targetNote.DeletedTime = note.DeletedTime;
        }

        public static NoteEntity ToEntity(this Note model)
        {
            return new NoteEntity()
            {
                Id = model.Id,
                AuthorId = model.AuthorId,
                Title = model.Title,
                Remark = model.Remark,
                CreateTime = model.CreateTime,
                LastBrowsedTime = model.LastBrowsedTime,
                IsShared = model.IsShared,
                IsDeleted = model.IsDeleted,
                DeletedTime = model.DeletedTime
            };
        }
    }
}
