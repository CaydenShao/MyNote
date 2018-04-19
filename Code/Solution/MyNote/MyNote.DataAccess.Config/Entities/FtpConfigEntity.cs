using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Config.Entities
{
    public class FtpConfigEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public bool IsNeedAuthentication { get; set; }
        public string VirticalDir { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
