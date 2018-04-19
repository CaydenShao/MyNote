using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Common.Bases
{
    public class ResultBase
    {
        public ResultBase()
        {
            this.Code = 0;
            this.Description = string.Empty;
        }

        public int Code { get; set; }

        public string Description { get; set; }
    }
}
