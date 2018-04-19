using MyNote.Business.Common;
using MyNote.Business.NoteUser.Interface;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.DataAccess.NoteUser.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.NoteUser.Business.V1
{
    public class VerificationBusinessV1 : IVerificationManager
    {
        private static VerificationBusinessV1 instance = null;
        private static object syncRoot = new object();

        #region Public methods

        public ManagerResult<Verification> GetVerificationById(int id)
        {
            ManagerResult<Verification> result = new ManagerResult<Verification>();

            try
            {
                Verification verification = VerificationDAL.Instance.GetVerificationById(id);

                if (verification == null)
                {
                    result.Code = 1;
                    result.Description = "未找到符合条件的验证信息！";
                    result.ResultData = null;
                }
                else
                {
                    result.Code = 0;
                    result.Description = "验证信息获取成功！";
                    result.ResultData = verification;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<Verification> GetVerificationByPhoneNumber(string phoneNumber)
        {
            ManagerResult<Verification> result = new ManagerResult<Verification>();

            try
            {
                Verification verification = VerificationDAL.Instance.GetVerificationByPhoneNumber(phoneNumber);

                if (verification == null)
                {
                    result.Code = 1;
                    result.Description = "未找到符合条件的验证信息！";
                }
                else
                {
                    result.Code = 0;
                    result.Description = "验证信息获取成功！";
                    result.ResultData = verification;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<Verification> AddVerification(Verification verification)
        {
            ManagerResult<Verification> result = new ManagerResult<Verification>();

            try
            {
                Verification newVerification = VerificationDAL.Instance.AddVerification(verification);

                if (newVerification == null)
                {
                    result.Code = 1;
                    result.Description = "添加失败！";
                }
                else
                {
                    result.Code = 0;
                    result.Description = "添加成功！";
                    result.ResultData = verification;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<Verification> GenerateVerification(string phoneNumber)
        {
            ManagerResult<Verification> result = new ManagerResult<Verification>();

            try
            {
                Verification newVerification = VerificationDAL.Instance.AddVerification(new Verification()
                {
                    PhoneNumber = phoneNumber,
                    Code = CheckCodeHelper.GenerateCheckCode(5)
                });

                if (newVerification == null)
                {
                    result.Code = 1;
                    result.Description = "生成失败！";
                    result.ResultData = null;
                }
                else
                {
                    result.Code = 0;
                    result.Description = "生成成功！";
                    result.ResultData = newVerification;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<bool> CheckVerification(string phoneNumber, string code)
        {
            ManagerResult<bool> result = new ManagerResult<bool>();

            try
            {
                Verification newVerification = VerificationDAL.Instance.GetVerificationByPhoneNumber(phoneNumber);

                if (newVerification == null)
                {
                    result.Code = 1;
                    result.Description = "手机号码无效！";
                    result.ResultData = false;
                }
                else
                {
                    if (newVerification.Code.Equals(code))
                    {
                        double secondGap = DateTime.Now.Subtract(newVerification.StartTime).TotalSeconds;

                        if (secondGap > 0 && secondGap < 60)
                        {
                            result.Code = 0;
                            result.Description = "验证成功！";
                            result.ResultData = true;
                        }
                        else
                        {
                            result.Code = 3;
                            result.Description = "验证码已超时！";
                            result.ResultData = false;
                        }
                    }
                    else
                    {
                        result.Code = 2;
                        result.Description = "验证码错误！";
                        result.ResultData = false;
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

        #endregion
    }
}
