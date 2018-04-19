using MyNote.Contracts.DataContracts.Notes;
using MyNote.EFDataAccess.Entities.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Extensions.Notes
{
    public static class NoteContentExtension
    {
        public static NoteContent ToModel(this NoteContentEntity entity)
        {
            return new NoteContent()
            {
                Id = entity.Id,
                NoteId = entity.NoteId,
                Type = entity.Type,
                Content = entity.Content,
                CreateTime = entity.CreateTime,
                IsDeleted = entity.IsDeleted,
                DeletedTime = entity.DeletedTime
            };
        }

        public static void CopyTo(this NoteContentEntity noteContentEntity, NoteContent targetNoteContent)
        {
            targetNoteContent.Id = noteContentEntity.Id;
            targetNoteContent.NoteId = noteContentEntity.NoteId;
            targetNoteContent.Type = noteContentEntity.Type;
            targetNoteContent.Content = noteContentEntity.Content;
            targetNoteContent.CreateTime = noteContentEntity.CreateTime;
            targetNoteContent.IsDeleted = noteContentEntity.IsDeleted;
            targetNoteContent.DeletedTime = noteContentEntity.DeletedTime;
        }

        public static NoteContentEntity ToEntity(this NoteContent model)
        {
            return new NoteContentEntity()
            {
                Id = model.Id,
                NoteId = model.NoteId,
                Type = model.Type,
                Content = model.Content,
                CreateTime = model.CreateTime,
                IsDeleted = model.IsDeleted,
                DeletedTime = model.DeletedTime
            };
        }
    }
}
