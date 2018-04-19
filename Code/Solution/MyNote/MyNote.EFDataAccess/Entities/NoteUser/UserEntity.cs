using MyNote.EFDataAccess.Entities.Notes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Entities.NoteUser
{
    [Table("NoteUser")]
    public class UserEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name"), Required, MaxLength(20)]
        public string Name { get; set; }

        [Column("PhoneNumber"), Index(IsUnique = true), Required, MaxLength(20), Index(IsUnique = true)]
        public string PhoneNumber { get; set; }

        [Column("Email"), Index(IsUnique = true), MaxLength(128)]
        public string Email { get; set; }

        [Column("ProfilePicture"), Index(IsUnique = true), MaxLength(256)]
        public string ProfilePicture { get; set; }

        [Column("HashCode"), Required, MaxLength(128)]
        public string HashCode { get; set; }

        [Column("Salt"), Required, MaxLength(128)]
        public string Salt { get; set; }

        [Column("CreateTime"), Required]
        public DateTime CreateTime { get; set; }

        [Column("LastLoginTime"), Required]
        public DateTime LastLoginTime { get; set; }

        [Column("LastLoginAddress"), Required]
        public string LastLoginAddress { get; set; }

        [Column("Token"), Required, MaxLength(128)]
        public string Token { get; set; }

        [Column("VerificationCode"), MaxLength(128)]
        public string VerificationCode { get; set; }

        //[InverseProperty("User")]
        public virtual ICollection<NoteEntity> Notes { get; set; } // Note的导航

        //[InverseProperty("User")]
        public virtual ICollection<NoteBrowsedRecordEntity> NoteBrowsedRecords { get; set; } // NoteBrowsedRecord的导航

        //[InverseProperty("User")]
        public virtual ICollection<NoteApprovedRecordEntity> NoteApprovedRecords { get; set; } // NoteApprovedRecord的导航

        //[InverseProperty("User")]
        public virtual ICollection<NoteCommentEntity> NoteComments { get; set; } // NoteComment导航
    }
}
