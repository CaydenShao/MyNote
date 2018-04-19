using MyNote.Business.Common.Interface;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Common.Models;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.DataAccess.NoteUser.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Common.Business.V1
{
    public class SecurityCheckBusinessV1 : ISecurityCheckManager
    {
        public ManagerResult<bool> CheckToken(int id, string token)
        {
            ManagerResult<bool> result = new ManagerResult<bool>();

            try
            {
                if (id <= 0 || string.IsNullOrEmpty(token))
                {
                    result.ResultData = false;
                    result.Code = 2;
                    result.Description = "参数为空或不符合规范！";
                }
                else
                {
                    User user = UserDAL.Instance.GetUserByIdAndToken(id, token);

                    if (user == null)
                    {
                        result.ResultData = false;
                        result.Code = 1;
                        result.Description = "用户不存在！";
                    }
                    else
                    {
                        result.ResultData = true;
                        result.Code = 0;
                        result.Description = "验证成功！";
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<bool> CheckSignature(string signature, string timestamp, string nonce, string appId)
        {
            ManagerResult<bool> result = new ManagerResult<bool>();

            try
            {
                SignCheckResult checkResult = Signature.ValidateSignature(signature, timestamp, nonce, appId);
                result.Description = checkResult.Description;

                if (!checkResult.IsSuccess)
                {
                    result.ResultData = false;
                    result.Code = 1;
                }
                else
                {
                    result.ResultData = true;
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
