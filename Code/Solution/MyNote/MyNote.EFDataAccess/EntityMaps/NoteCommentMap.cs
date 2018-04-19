using MyNote.EFDataAccess.Entities.Notes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.EntityMaps
{
    public class NoteCommentMap : EntityTypeConfiguration<NoteCommentEntity>
    {
        public NoteCommentMap()
        {
            HasMany(nc => nc.CommentContents)
                .WithRequired(cc => cc.NoteComment)
                .HasForeignKey(cc => cc.CommentId)
                .WillCascadeOnDelete(false);
        }
    }
}
