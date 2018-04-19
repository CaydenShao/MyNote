using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.DataAccess.Common;
using MyNote.DataAccess.NoteUser.Extensions;
using MyNote.DataAccess.NoteUser.Entities;
using MyNote.DataAccess.NoteUser.ProcedureContainer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.NoteUser.DAL
{
    public class UserDAL
    {
        private static UserDAL instance;
        private static object syncRoot = new object();

        #region Constructors

        private UserDAL()
        { }

        #endregion

        #region Properties

        public static object SyncRoot
        {
            get
            {
                return syncRoot;
            }
        }

        public static UserDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new UserDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public User AddUser(UserEntity user)
        {
            try
            {
                if (user == null)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Insert_NoteUser_Name,
                        Value = user.Name
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Insert_NoteUser_PhoneNumber,
                        Value = user.PhoneNumber
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Insert_NoteUser_HashCode,
                        Value = user.HashCode
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Insert_NoteUser_Salt,
                        Value = user.Salt
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Insert_NoteUser_LastLoginAddress,
                        Value = user.LastLoginAddress
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteUser.Sp_Insert_NoteUser, parameters))
                {
                    UserEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new UserEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            Name = dataRow[dataColumns[1]].ToString(),
                            PhoneNumber = dataRow[dataColumns[2]].ToString(),
                            Email = dataRow[dataColumns[3]].ToString(),
                            ProfilePicture = dataRow[dataColumns[4]].ToString(),
                            HashCode = dataRow[dataColumns[5]].ToString(),
                            Salt = dataRow[dataColumns[6]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[7]],
                            LastLoginTime = (DateTime)dataRow[dataColumns[8]],
                            LastLoginAddress = dataRow[dataColumns[9]].ToString(),
                            Token = dataRow[dataColumns[10]].ToString(),
                            VerificationCode = dataRow[dataColumns[11]].ToString()
                        };
                    }

                    if (entity == null)
                    {
                        return null;
                    }

                    return entity.ToModel();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Select_NoteUserById_Id,
                        Value = id
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteUser.Sp_Select_NoteUserById, parameters))
                {
                    UserEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new UserEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            Name = dataRow[dataColumns[1]].ToString(),
                            PhoneNumber = dataRow[dataColumns[2]].ToString(),
                            Email = dataRow[dataColumns[3]].ToString(),
                            ProfilePicture = dataRow[dataColumns[4]].ToString(),
                            HashCode = dataRow[dataColumns[5]].ToString(),
                            Salt = dataRow[dataColumns[6]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[7]],
                            LastLoginTime = (DateTime)dataRow[dataColumns[8]],
                            LastLoginAddress = dataRow[dataColumns[9]].ToString(),
                            Token = dataRow[dataColumns[10]].ToString(),
                            VerificationCode = dataRow[dataColumns[11]].ToString()
                        };
                    }

                    if (entity == null)
                    {
                        return null;
                    }

                    return entity.ToModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserByIdDR(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Select_NoteUserById_Id,
                        Value = id
                    }
                };

                UserEntity entity = DbHelper.RunProcedureGetDataReader<UserEntity>(SpNamesOfNoteUser.Sp_Select_NoteUserById, parameters, dataReader =>
                {
                    dataReader.Read();

                    entity = new UserEntity()
                    {
                        Id = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        PhoneNumber = dataReader.GetString(2),
                        Email = dataReader.IsDBNull(3) ? null : dataReader.GetString(3),
                        ProfilePicture = dataReader.IsDBNull(4) ? null : dataReader.GetString(4),
                        HashCode = dataReader.GetString(5),
                        Salt = dataReader.GetString(6),
                        CreateTime = dataReader.GetDateTime(7),
                        LastLoginTime = dataReader.GetDateTime(8),
                        LastLoginAddress = dataReader.GetString(9),
                        Token = dataReader.GetString(10),
                        VerificationCode = dataReader.IsDBNull(11) ? null : dataReader.GetString(11)
                    };

                    return entity;
                });

                if (entity == null)
                {
                    return null;
                }

                return entity.ToModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserByPhoneNumber(string phoneNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Select_NoteUserByPhoneNumber_PhoneNumber,
                        Value = phoneNumber
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteUser.Sp_Select_NoteUserByPhoneNumber, parameters))
                {
                    UserEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new UserEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            Name = dataRow[dataColumns[1]].ToString(),
                            PhoneNumber = dataRow[dataColumns[2]].ToString(),
                            Email = dataRow[dataColumns[3]].ToString(),
                            ProfilePicture = dataRow[dataColumns[4]].ToString(),
                            HashCode = dataRow[dataColumns[5]].ToString(),
                            Salt = dataRow[dataColumns[6]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[7]],
                            LastLoginTime = (DateTime)dataRow[dataColumns[8]],
                            LastLoginAddress = dataRow[dataColumns[9]].ToString(),
                            Token = dataRow[dataColumns[10]].ToString(),
                            VerificationCode = dataRow[dataColumns[11]].ToString()
                        };
                    }

                    return entity == null ? null : entity.ToModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserEntity GetUserEntityByPhoneNumber(string phoneNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Select_NoteUserByPhoneNumber_PhoneNumber,
                        Value = phoneNumber
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteUser.Sp_Select_NoteUserByPhoneNumber, parameters))
                {
                    UserEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new UserEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            Name = dataRow[dataColumns[1]].ToString(),
                            PhoneNumber = dataRow[dataColumns[2]].ToString(),
                            Email = dataRow[dataColumns[3]].ToString(),
                            ProfilePicture = dataRow[dataColumns[4]].ToString(),
                            HashCode = dataRow[dataColumns[5]].ToString(),
                            Salt = dataRow[dataColumns[6]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[7]],
                            LastLoginTime = (DateTime)dataRow[dataColumns[8]],
                            LastLoginAddress = dataRow[dataColumns[9]].ToString(),
                            Token = dataRow[dataColumns[10]].ToString(),
                            VerificationCode = dataRow[dataColumns[11]].ToString()
                        };
                    }

                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserByToken(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Select_NoteUserByToken_Token,
                        Value = token
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteUser.Sp_Select_NoteUserByToken, parameters))
                {
                    UserEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new UserEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            Name = dataRow[dataColumns[1]].ToString(),
                            PhoneNumber = dataRow[dataColumns[2]].ToString(),
                            Email = dataRow[dataColumns[3]].ToString(),
                            ProfilePicture = dataRow[dataColumns[4]].ToString(),
                            HashCode = dataRow[dataColumns[5]].ToString(),
                            Salt = dataRow[dataColumns[6]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[7]],
                            LastLoginTime = (DateTime)dataRow[dataColumns[8]],
                            LastLoginAddress = dataRow[dataColumns[9]].ToString(),
                            Token = dataRow[dataColumns[10]].ToString(),
                            VerificationCode = dataRow[dataColumns[11]].ToString()
                        };
                    }

                    if (entity == null)
                    {
                        return null;
                    }

                    return entity.ToModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserByIdAndToken(int id, string token)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(token))
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Select_NoteUserByIdAndToken_Id,
                        Value = id
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Select_NoteUserByIdAndToken_Token,
                        Value = token
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteUser.Sp_Select_NoteUserByIdAndToken, parameters))
                {
                    UserEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new UserEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            Name = dataRow[dataColumns[1]].ToString(),
                            PhoneNumber = dataRow[dataColumns[2]].ToString(),
                            Email = dataRow[dataColumns[3]].ToString(),
                            ProfilePicture = dataRow[dataColumns[4]].ToString(),
                            HashCode = dataRow[dataColumns[5]].ToString(),
                            Salt = dataRow[dataColumns[6]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[7]],
                            LastLoginTime = (DateTime)dataRow[dataColumns[8]],
                            LastLoginAddress = dataRow[dataColumns[9]].ToString(),
                            Token = dataRow[dataColumns[10]].ToString(),
                            VerificationCode = dataRow[dataColumns[11]].ToString()
                        };
                    }

                    if (entity == null)
                    {
                        return null;
                    }

                    return entity.ToModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User UpdateTokenById(int id, string token)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(token))
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Update_NoteUserToken_Id,
                        Value = id
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteUser.Sp_Update_NoteUserToken_Token,
                        Value = token
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteUser.Sp_Update_NoteUserToken, parameters))
                {
                    UserEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new UserEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            Name = dataRow[dataColumns[1]].ToString(),
                            PhoneNumber = dataRow[dataColumns[2]].ToString(),
                            Email = dataRow[dataColumns[3]].ToString(),
                            ProfilePicture = dataRow[dataColumns[4]].ToString(),
                            HashCode = dataRow[dataColumns[5]].ToString(),
                            Salt = dataRow[dataColumns[6]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[7]],
                            LastLoginTime = (DateTime)dataRow[dataColumns[8]],
                            LastLoginAddress = dataRow[dataColumns[9]].ToString(),
                            Token = dataRow[dataColumns[10]].ToString(),
                            VerificationCode = dataRow[dataColumns[11]].ToString()
                        };
                    }

                    if (entity == null)
                    {
                        return null;
                    }

                    return entity.ToModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
