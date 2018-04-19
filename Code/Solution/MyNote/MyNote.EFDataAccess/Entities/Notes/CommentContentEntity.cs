using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Entities.Notes
{
    [Table("CommentContent")]
    public class CommentContentEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 生成外键
        [Column("CommentId"), Required]
        public int CommentId { get; set; }

        //[InverseProperty("CommentContents")]
        public virtual NoteCommentEntity NoteComment { get; set; } // NoteComment导航

        [Column("Type"), Required]
        public int Type { get; set; }

        [Column("Content"), Required]
        public string Content { get; set; }

        [Column("CreateTime"), Required]
        public DateTime CreateTime { get; set; }
    }
}
