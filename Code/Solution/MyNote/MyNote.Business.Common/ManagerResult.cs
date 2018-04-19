using MyNote.Business.Common.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Common
{
    public class ManagerResult<T> : ResultBase
    {
        public ManagerResult() : base()
        { }

        public T ResultData { get; set; }
    }
}
