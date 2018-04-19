using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Entities.Notes
{
    [Table("NoteContent")]
    public class NoteContentEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int NoteId { get; set; }

        //[InverseProperty("NoteContents")]
        public virtual NoteEntity Note { get; set; } // 所属Note的导航

        [Column("Type"), Required]
        public int Type { get; set; }

        [Column("Content"), Required]
        public string Content { get; set; }

        [Column("CreateTime"), Required]
        public DateTime CreateTime { get; set; }

        [Column("IsDeleted"), Required]
        public bool IsDeleted { get; set; }

        [Column("DeletedTime"), Required]
        public DateTime DeletedTime { get; set; }
    }
}
