using MyNote.Common.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.Bases
{
    public class RequestBase
    {
        public RequestBase()
        {
            Version = Versions.V1_0;
        }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
    }
}
