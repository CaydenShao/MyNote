using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Common.Bases
{
    public class ManagerBase
    {
        private string version = string.Empty;

        public ManagerBase(string version)
        {
            this.version = version;
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }
}
