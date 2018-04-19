using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Entities.Config
{
    [Table("FtpConfig")]
    public class FtpConfigEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name"), Index(IsUnique = true), Required, MaxLength(128)]
        public string Name { get; set; }

        [Column("Description"), Required]
        public string Description { get; set; }

        [Column("IP"), Required, MaxLength(15)]
        public string IP { get; set; }

        [Column("Port"), Required]
        public int Port { get; set; }

        [Column("IsNeedAuthentication"), Required]
        public bool IsNeedAuthentication { get; set; }

        [Column("VirticalDir"), Required, MaxLength(128)]
        public string VirticalDir { get; set; }

        [Column("UserName"), Required, MaxLength(128)]
        public string UserName { get; set; }

        [Column("Password"), Required, MaxLength(128)]
        public string Password { get; set; }
    }
}
