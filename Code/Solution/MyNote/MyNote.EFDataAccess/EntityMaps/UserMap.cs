using MyNote.EFDataAccess.Entities.NoteUser;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.EntityMaps
{
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            HasMany(u => u.Notes)
                .WithRequired(n => n.User)
                .HasForeignKey(n => n.AuthorId)
                .WillCascadeOnDelete(false);

            HasMany(u => u.NoteComments)
                .WithRequired(nc => nc.User)
                .HasForeignKey(nc => nc.CreatorId)
                .WillCascadeOnDelete(false);

            HasMany(u => u.NoteBrowsedRecords)
                .WithRequired(nb => nb.User)
                .HasForeignKey(nb => nb.UserId)
                .WillCascadeOnDelete(false);

            HasMany(u => u.NoteApprovedRecords)
                .WithRequired(na => na.User)
                .HasForeignKey(na => na.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
