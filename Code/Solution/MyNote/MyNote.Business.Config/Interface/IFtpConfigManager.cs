using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Config.Interface
{
    public interface IFtpConfigManager
    {
        ManagerResult<FtpConfig> AddFtpConfig(FtpConfig ftpConfig);

        ManagerResult<FtpConfig> GetFtpConfigById(int id);

        ManagerResult<FtpConfig> GetFtpConfigByName(string name);
    }
}
