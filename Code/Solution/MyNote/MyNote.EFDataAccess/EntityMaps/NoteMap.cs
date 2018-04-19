using MyNote.EFDataAccess.Entities.Notes;
using MyNote.EFDataAccess.Entities.NoteUser;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.EntityMaps
{
    public class NoteMap : EntityTypeConfiguration<NoteEntity>
    {
        public NoteMap()
        {
            HasMany(n => n.NoteContents)
                .WithRequired(nc => nc.Note)
                .HasForeignKey(nc => nc.NoteId)
                .WillCascadeOnDelete(false);

            HasMany(n => n.NoteComments)
                .WithRequired(nc => nc.Note)
                .HasForeignKey(nc => nc.NoteId)
                .WillCascadeOnDelete(false);

            HasMany(n => n.NoteBrowsedRecords)
                .WithRequired(nb => nb.Note)
                .HasForeignKey(nc => nc.NoteId)
                .WillCascadeOnDelete(false);

            HasMany(n => n.NoteApprovedRecords)
                .WithRequired(wo => wo.Note)
                .HasForeignKey(wo => wo.NoteId)
                .WillCascadeOnDelete(false);
        }
    }
}
