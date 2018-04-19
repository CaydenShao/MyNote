using MyNote.Contracts.DataContracts.Notes;
using MyNote.DataAccess.Notes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.Extensions
{
    public static class NoteCommentExtension
    {
        public static NoteComment ToModel(this NoteCommentEntity entity)
        {
            return new NoteComment()
            {
                Id = entity.Id,
                NoteId = entity.NoteId,
                CreatorId = entity.CreatorId,
                CommentId = entity.CommentId,
                CreateTime = entity.CreateTime,
                IsDeleted = entity.IsDeleted,
                DeletedTime = entity.DeletedTime
            };
        }

        public static NoteCommentEntity ToEntity(this NoteComment model)
        {
            return new NoteCommentEntity()
            {
                Id = model.Id,
                NoteId = model.NoteId,
                CreatorId = model.CreatorId,
                CommentId = model.CommentId,
                CreateTime = model.CreateTime,
                IsDeleted = model.IsDeleted,
                DeletedTime = model.DeletedTime
            };
        }
    }
}
