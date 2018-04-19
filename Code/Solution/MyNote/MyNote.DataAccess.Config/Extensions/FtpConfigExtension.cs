using MyNote.Contracts.DataContracts.Config;
using MyNote.DataAccess.Config.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Config.Extensions
{
    public static class FtpConfigExtension
    {
        public static FtpConfig ToModel(this FtpConfigEntity ftpConfig)
        {
            return new FtpConfig()
            {
                Id = ftpConfig.Id,
                Name = ftpConfig.Name,
                Description = ftpConfig.Description,
                IP = ftpConfig.IP,
                Port = ftpConfig.Port,
                IsNeedAuthentication = ftpConfig.IsNeedAuthentication,
                VirticalDir = ftpConfig.VirticalDir,
                UserName = ftpConfig.UserName,
                Password = ftpConfig.Password
            };
        }

        public static FtpConfigEntity ToEntity(this FtpConfig ftpConfig)
        {
            return new FtpConfigEntity()
            {
                Id = ftpConfig.Id,
                Name = ftpConfig.Name,
                Description = ftpConfig.Description,
                IP = ftpConfig.IP,
                Port = ftpConfig.Port,
                IsNeedAuthentication = ftpConfig.IsNeedAuthentication,
                VirticalDir = ftpConfig.VirticalDir,
                UserName = ftpConfig.UserName,
                Password = ftpConfig.Password
            };
        }
    }
}
