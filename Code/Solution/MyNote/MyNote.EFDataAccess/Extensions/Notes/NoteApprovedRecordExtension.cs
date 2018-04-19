using MyNote.Contracts.DataContracts.Notes;
using MyNote.EFDataAccess.Entities.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Extensions.Notes
{
    public static class NoteApprovedRecordExtension
    {
        public static NoteApprovedRecord ToModel(this NoteApprovedRecordEntity entity)
        {
            return new NoteApprovedRecord()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                NoteId = entity.NoteId,
                ApprovedTime = entity.ApprovedTime,
                IsCanceled = entity.IsCanceled,
                CanceledTime = entity.CanceledTime
            };
        }

        public static NoteApprovedRecordEntity ToEntity(this NoteApprovedRecord model)
        {
            return new NoteApprovedRecordEntity()
            {
                Id = model.Id,
                UserId = model.UserId,
                NoteId = model.NoteId,
                ApprovedTime = model.ApprovedTime,
                IsCanceled = model.IsCanceled,
                CanceledTime = model.CanceledTime
            };
        }
    }
}
