using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.Bases
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            this.Code = 0;
            this.Description = string.Empty;
            this.HasAccessed = true;
        }

        public int Code { get; set; }

        public string Description { get; set; }

        public bool HasAccessed { get; set; }
    }
}
