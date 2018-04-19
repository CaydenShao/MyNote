using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Config;
using MyNote.Contracts.DataContracts.Config.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Contracts.WebApiInterface.Config
{
    public interface ISysInfoServices
    {
        Response<SysInfo> GetSysInfoById(PublicRequest<GetSysInfoByIdRequest> request);

        Response<SysInfo> GetSysInfoByName(PublicRequest<GetSysInfoByNameRequest> request);

        Response<SysInfo> AddSysInfo(TokenRequest<SysInfo> request);
    }
}
