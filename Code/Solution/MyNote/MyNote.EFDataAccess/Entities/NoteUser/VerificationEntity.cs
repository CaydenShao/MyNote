using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Entities.NoteUser
{
    [Table("Verification")]
    public class VerificationEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("PhoneNumber"), Index(IsUnique = true), Required, MaxLength(20), Index(IsUnique = true)]
        public string PhoneNumber { get; set; }

        [Column("StartTime"), Required]
        public DateTime StartTime { get; set; }

        [Column("Code"), Required, MaxLength(20), Index(IsUnique = true)]
        public string Code { get; set; }
    }
}
