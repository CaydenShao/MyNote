using MyNote.Business.Common;
using MyNote.Business.Config.Interface;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.Config;
using MyNote.DataAccess.Config.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Config.Business.V1
{
    public class FtpConfigBusinessV1 : IFtpConfigManager
    {
        public ManagerResult<FtpConfig> AddFtpConfig(FtpConfig ftpConfig)
        {
            ManagerResult<FtpConfig> result = new ManagerResult<FtpConfig>();

            try
            {
                result.ResultData = FtpConfigDAL.Instance.AddFtpConfig(ftpConfig);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "配置项添加失败!";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<FtpConfig> GetFtpConfigById(int id)
        {
            ManagerResult<FtpConfig> result = new ManagerResult<FtpConfig>();

            try
            {
                result.ResultData = FtpConfigDAL.Instance.GetFtpConfigById(id);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "记录不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<FtpConfig> GetFtpConfigByName(string name)
        {
            ManagerResult<FtpConfig> result = new ManagerResult<FtpConfig>();

            try
            {
                result.ResultData = FtpConfigDAL.Instance.GetFtpConfigByName(name);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "记录不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }
    }
}
