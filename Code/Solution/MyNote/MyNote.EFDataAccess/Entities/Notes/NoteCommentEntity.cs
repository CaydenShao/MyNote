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
    [Table("NoteComment")]
    public class NoteCommentEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 生成外键
        public int NoteId { get; set; }

        //[InverseProperty("NoteComments")]
        public virtual NoteEntity Note { get; set; }

        // 生成外键
        public int CreatorId { get; set; }

        //[InverseProperty("NoteComments")]
        public virtual UserEntity User { get; set; } // User导航

        // 生成外键
        [Column("CommentId")]
        public int CommentId { get; set; }

        [Column("CreateTime"), Required]
        public DateTime CreateTime { get; set; }

        [Column("IsDeleted"), Required]
        public bool IsDeleted { get; set; }

        [Column("DeletedTime"), Required]
        public DateTime DeletedTime { get; set; }

        //[InverseProperty("NoteComment")]
        public virtual ICollection<CommentContentEntity> CommentContents { get; set; } // CommentContent导航
    }
}
