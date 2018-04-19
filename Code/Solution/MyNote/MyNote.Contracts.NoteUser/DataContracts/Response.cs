using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts
{
    public class Response<T> : ResponseBase
    {
        public T ResponseData { get; set; }
    }
}
