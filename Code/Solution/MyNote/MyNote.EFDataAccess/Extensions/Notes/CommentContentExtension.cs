using MyNote.Contracts.DataContracts.Notes;
using MyNote.EFDataAccess.Entities.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Extensions.Notes
{
    public static class CommentContentExtension
    {
        public static NoteCommentContent ToModel(this CommentContentEntity entity)
        {
            return new NoteCommentContent()
            {
                Id = entity.Id,
                CommentId = entity.CommentId,
                Type = entity.Type,
                CreateTime = entity.CreateTime,
                Content = entity.Content
            };
        }

        public static CommentContentEntity ToEntity(this NoteCommentContent model)
        {
            return new CommentContentEntity()
            {
                Id = model.Id,
                CommentId = model.CommentId,
                Type = model.Type,
                CreateTime = model.CreateTime,
                Content = model.Content
            };
        }
    }
}
