using MyNote.Contracts.Bases;
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
    public interface IFtpConfigServices
    {
        Response<FtpConfig> AddFtpConfig(TokenRequest<FtpConfig> request);

        Response<FtpConfig> GetFtpConfigById(TokenRequest<GetFtpConfigByIdRequest> request);

        Response<FtpConfig> GetFtpConfigByName(TokenRequest<GetFtpConfigByNameRequest> request);
    }
}
