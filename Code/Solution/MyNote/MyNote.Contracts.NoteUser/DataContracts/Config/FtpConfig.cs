using MyNote.Common.Helpers;
using MyNote.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.DataContracts.Config
{
    public class FtpConfig : DataContractBase
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

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name)
                || string.IsNullOrEmpty(Description)
                || !ArgumentVerify.IsIPv4(IP)
                || !ArgumentVerify.IsPort(Port)
                || string.IsNullOrEmpty(VirticalDir)
                || string.IsNullOrEmpty(UserName)
                || string.IsNullOrEmpty(Password))
            {
                throw new ArgumentException();
            }
        }
    }
}
