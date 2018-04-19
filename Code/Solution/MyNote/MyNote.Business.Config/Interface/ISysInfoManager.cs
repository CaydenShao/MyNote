using MyNote.Business.Common;
using MyNote.Contracts.DataContracts.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Config.Interface
{
    public interface ISysInfoManager
    {
        ManagerResult<DateTime> GetNowTime();

        ManagerResult<SysInfo> AddSysInfo(SysInfo sysInfo);

        ManagerResult<SysInfo> GetSysInfoById(int id);

        ManagerResult<SysInfo> GetSysInfoByName(string name);
    }
}
