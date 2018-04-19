using MyNote.Business.Common;
using MyNote.Business.Common.Bases;
using MyNote.Business.Common.Extensions;
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

namespace MyNote.Business.Config.Manager
{
    public class SysInfoManager : ManagerBase, ISysInfoManager
    {
        #region Constructors

        public SysInfoManager(string version) 
            : base(version)
        { }

        #endregion

        #region Public methods

        public ManagerResult<DateTime> GetNowTime()
        {
            ManagerResult<DateTime> result = new ManagerResult<DateTime>();

            try
            {
                result.ResultData = DateTime.Now;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<SysInfo> AddSysInfo(SysInfo sysInfo)
        {
            ManagerResult<SysInfo> result = new ManagerResult<SysInfo>();

            try
            {
                result.ResultData = SysInfoDAL.Instance.AddSysInfo(sysInfo);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "配置项添加失败！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<SysInfo> GetSysInfoById(int id)
        {
            ManagerResult<SysInfo> result = new ManagerResult<SysInfo>();

            try
            {
                result.ResultData = SysInfoDAL.Instance.GetSysInfoById(id);

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

        public ManagerResult<SysInfo> GetSysInfoByName(string name)
        {
            ManagerResult<SysInfo> result = new ManagerResult<SysInfo>();

            try
            {
                result.ResultData = SysInfoDAL.Instance.GetSysInfoByName(name);

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

        #endregion
    }
}
