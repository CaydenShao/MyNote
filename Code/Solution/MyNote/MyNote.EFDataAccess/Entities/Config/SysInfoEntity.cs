using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.Entities.Config
{
    [Table("SysInfo")]
    public class SysInfoEntity
    {
        [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name"), Index(IsUnique = true), Required, MaxLength(128)]
        public string Name { get; set; }

        [Column("Description"), Required, MaxLength(128)]
        public string Description { get; set; }

        [Column("Detail"), Required]
        public string Detail { get; set; }
    }
}
