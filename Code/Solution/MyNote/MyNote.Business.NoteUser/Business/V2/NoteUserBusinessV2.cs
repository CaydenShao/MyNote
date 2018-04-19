using MyNote.Business.Common;
using MyNote.Business.NoteUser.Interface;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.EFDataAccess.DAL.NoteUser;
using MyNote.EFDataAccess.Entities.NoteUser;
using MyNote.EFDataAccess.Extensions.NoteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.NoteUser.Business.V2
{
    public class NoteUserBusinessV2 : INoteUserManager
    {
        #region Public methods

        public ManagerResult<User> GetUserById(int id)
        {
            ManagerResult<User> result = new ManagerResult<User>();

            try
            {
                result.ResultData = UserDAL.Instance.GetUserById(id);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "用户不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<User> GetUserByPhoneNumber(string phoneNumber)
        {
            ManagerResult<User> result = new ManagerResult<User>();

            try
            {
                result.ResultData = UserDAL.Instance.GetUserByPhoneNumber(phoneNumber);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "用户不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<User> GetUserByToken(string token)
        {
            ManagerResult<User> result = new ManagerResult<User>();

            try
            {
                result.ResultData = UserDAL.Instance.GetUserByToken(token);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "用户不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<User> GetUserByIdAndToken(int id, string token)
        {
            ManagerResult<User> result = new ManagerResult<User>();

            try
            {
                result.ResultData = UserDAL.Instance.GetUserByIdAndToken(id, token);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "用户不存在！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<User> Register(User user, string pwdHashStr)
        {
            ManagerResult<User> result = new ManagerResult<User>();

            try
            {
                UserEntity entity = user.ToEntity();
                SHA256CrypWidthSalt crp = SHA256CrypWidthSalt.Encrypt(pwdHashStr);
                entity.HashCode = crp.HashString;
                entity.Salt = crp.Salt;
                result.ResultData = UserDAL.Instance.AddUser(entity);

                if (result.ResultData == null)
                {
                    result.Code = 1;
                    result.Description = "添加用户失败！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
                result.Code = -1;
            }

            return result;
        }

        public ManagerResult<User> Login(string phoneNumber, string password)
        {
            ManagerResult<User> result = new ManagerResult<User>();

            try
            {
                UserEntity user = UserDAL.Instance.GetUserEntityByPhoneNumber(phoneNumber);

                if (user == null)
                {
                    result.ResultData = null;
                    result.Code = 1;
                    result.Description = "账号不存在！";
                }
                else
                {
                    if (SHA256CrypWidthSalt.IsMatch(password, user.Salt, user.HashCode))
                    {
                        result.ResultData = UserDAL.Instance.UpdateTokenById(user.Id, Guid.NewGuid().ToString());

                        if (result.ResultData == null)
                        {
                            result.Code = 2;
                            result.Description = "Token更新失败！";
                        }
                        else
                        {
                            result.Code = 0;
                            result.Description = "验证成功！";
                        }
                    }
                    else
                    {
                        result.ResultData = null;
                        result.Code = 2;
                        result.Description = "密码错误！";
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

        public ManagerResult<bool> CheckPhoneNumberRegistered(string phoneNumber)
        {
            ManagerResult<bool> result = new ManagerResult<bool>();

            try
            {
                User user = UserDAL.Instance.GetUserByPhoneNumber(phoneNumber);

                if (user == null)
                {
                    result.ResultData = false;
                    result.Description = "该手机号未被注册！";
                    result.Code = 0;
                }
                else
                {
                    result.ResultData = true;
                    result.Description = "该手机号已被注册！";
                    result.Code = 0;
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
