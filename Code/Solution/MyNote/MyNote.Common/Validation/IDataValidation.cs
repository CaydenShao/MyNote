using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Common.Validation
{
    public interface IDataValidation
    {
        /// <summary>
        /// Validate the data effectiveness.
        /// </summary>
        /// <exception cref="ArgumentNullException">If key data is null or invalid value.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If key data is out of valid range.</exception>
        void Validate();
    }
}
