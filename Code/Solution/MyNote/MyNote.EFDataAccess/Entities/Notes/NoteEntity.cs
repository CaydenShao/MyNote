using MyNote.EFDataAccess.Entities.NoteUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Entities.Notes
{
    [Table("Note")]
    public class NoteEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AuthorId { get; set; }

        //[InverseProperty("Notes")]
        public virtual UserEntity User { get; set; } // Note的创建者导航

        [Column("Title"), Required, MaxLength(128)]
        public string Title { get; set; }

        [Column("Remark"), Required, MaxLength(128)]
        public string Remark { get; set; }

        [Column("CreateTime"), Required]
        public DateTime CreateTime { get; set; }

        [Column("LastBrowsedTime"), Required]
        public DateTime LastBrowsedTime { get; set; }

        [Column("IsShared"), Required]
        public bool IsShared { get; set; }

        [Column("IsDeleted"), Required]
        public bool IsDeleted { get; set; }

        [Column("DeletedTime"), Required]
        public DateTime DeletedTime { get; set; }

        //[InverseProperty("Note")]
        public virtual ICollection<NoteContentEntity> NoteContents { get; set; } // NoteContent导航

        //[InverseProperty("Note")]
        public virtual ICollection<NoteCommentEntity> NoteComments { get; set; } // NoteComment导航

        //[InverseProperty("Note")]
        public virtual ICollection<NoteBrowsedRecordEntity> NoteBrowsedRecords { get; set; } // NoteBrowsedRecord导航

        //[InverseProperty("Note")]
        public virtual ICollection<NoteApprovedRecordEntity> NoteApprovedRecords { get; set; } // // NoteApprovedRecord导航
    }
}
