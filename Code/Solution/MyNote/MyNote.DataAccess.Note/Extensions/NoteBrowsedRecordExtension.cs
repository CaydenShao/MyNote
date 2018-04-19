using MyNote.Contracts.DataContracts.Notes;
using MyNote.DataAccess.Notes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.Extensions
{
    public static class NoteBrowsedRecordExtension
    {
        public static NoteBrowsedRecord ToModel(this NoteBrowsedRecordEntity entity)
        {
            return new NoteBrowsedRecord()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                NoteId = entity.NoteId,
                BrowsedTime = entity.BrowsedTime
            };
        }

        public static NoteBrowsedRecordEntity ToEntity(this NoteBrowsedRecord model)
        {
            return new NoteBrowsedRecordEntity()
            {
                Id = model.Id,
                UserId = model.UserId,
                NoteId = model.NoteId,
                BrowsedTime = model.BrowsedTime
            };
        }
    }
}
