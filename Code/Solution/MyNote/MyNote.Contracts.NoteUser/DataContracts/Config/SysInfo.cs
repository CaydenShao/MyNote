using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Config
{
    public class SysInfo : DataContractBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name)
                || string.IsNullOrEmpty(Description)
                || string.IsNullOrEmpty(Detail))
            {
                throw new ArgumentException();
            }
        }
    }
}
