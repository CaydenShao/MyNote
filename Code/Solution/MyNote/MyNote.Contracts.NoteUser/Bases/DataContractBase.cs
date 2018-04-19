using MyNote.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.Bases
{
    public abstract class DataContractBase : IDataValidation
    {
        public abstract void Validate();
    }
}
