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
    [Table("NoteApprovedRecord")]
    public class NoteApprovedRecordEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 生成外键
        public int UserId { get; set; }

        //[InverseProperty("NoteApprovedRecords")]
        public virtual UserEntity User { get; set; }  // User的导航

        // 生成外键
        public int NoteId { get; set; }

        //[InverseProperty("NoteApprovedRecords")]
        public virtual NoteEntity Note { get; set; } // Note的导航

        [Column("ApprovedTime"), Required]
        public DateTime ApprovedTime { get; set; }

        [Column("IsCanceled"), Required]
        public bool IsCanceled { get; set; }

        [Column("CanceledTime"), Required]
        public DateTime CanceledTime { get; set; }
    }
}
