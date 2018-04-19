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
    [Table("NoteBrowsedRecord")]
    public class NoteBrowsedRecordEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        //[InverseProperty("NoteBrowsedRecords")]
        public virtual UserEntity User { get; set; } // User的导航

        public int NoteId { get; set; }

        //[InverseProperty("NoteBrowsedRecords")]
        public virtual NoteEntity Note { get; set; } // Note的导航

        [Column("BrowsedTime"), Required]
        public DateTime BrowsedTime { get; set; }
    }
}
