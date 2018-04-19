using MyNote.Contracts.DataContracts.Config;
using MyNote.DataAccess.Common;
using MyNote.DataAccess.Config.Extensions;
using MyNote.DataAccess.Config.Entities;
using MyNote.DataAccess.Config.ProcedureContainer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Config.DAL
{
    public class FtpConfigDAL
    {
        private static FtpConfigDAL instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private FtpConfigDAL()
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

        public static FtpConfigDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            return instance;
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public FtpConfig AddFtpConfig(FtpConfig ftpConfig)
        {
            if (ftpConfig == null)
            {
                return null;
            }

            DbParameter[] parameters = new DbParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Insert_FtpConfig_Name,
                    Value = ftpConfig.Name
                },
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Insert_FtpConfig_Discription,
                    Value = ftpConfig.Description
                },
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Insert_FtpConfig_IP,
                    Value = ftpConfig.IP
                },
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Insert_FtpConfig_Port,
                    Value = ftpConfig.Port
                },
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Insert_FtpConfig_IsNeedAuthenticationt,
                    Value = ftpConfig.IsNeedAuthentication
                },
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Insert_FtpConfig_VirticalDir,
                    Value = ftpConfig.VirticalDir
                },
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Insert_FtpConfig_UserName,
                    Value = ftpConfig.UserName
                },
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Insert_FtpConfig_Password,
                    Value = ftpConfig.Password
                }
            };

            using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfFtpConfig.Sp_Insert_FtpConfig, parameters))
            {
                FtpConfigEntity entity = null;

                if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows.Count != 0)
                {
                    DataRow dataRow = dataSet.Tables[0].Rows[0];
                    DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                    entity = new FtpConfigEntity()
                    {
                        Id = (int)dataRow[dataColumns[0]],
                        Name = dataRow[dataColumns[1]].ToString(),
                        Description = dataRow[dataColumns[2]].ToString(),
                        IP = dataRow[dataColumns[3]].ToString(),
                        Port = (int)dataRow[dataColumns[4]],
                        IsNeedAuthentication = (bool)dataRow[dataColumns[5]],
                        VirticalDir = dataRow[dataColumns[6]].ToString(),
                        UserName = dataRow[dataColumns[7]].ToString(),
                        Password = dataRow[dataColumns[8]].ToString()
                    };
                }

                if (entity == null)
                {
                    return null;
                }

                return entity.ToModel();
            }
        }

        public FtpConfig GetFtpConfigById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            DbParameter[] parameters = new DbParameter[] 
            {
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Select_FtpConfigById_Id,
                    Value = id
                }
            };

            using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfFtpConfig.Sp_Select_FtpConfigById, parameters))
            {
                FtpConfigEntity entity = null;

                if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows.Count != 0)
                {
                    DataRow dataRow = dataSet.Tables[0].Rows[0];
                    DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                    entity = new FtpConfigEntity()
                    {
                        Id = (int)dataRow[dataColumns[0]],
                        Name = dataRow[dataColumns[1]].ToString(),
                        Description = dataRow[dataColumns[2]].ToString(),
                        IP = dataRow[dataColumns[3]].ToString(),
                        Port = (int)dataRow[dataColumns[4]],
                        IsNeedAuthentication = (bool)dataRow[dataColumns[5]],
                        VirticalDir = dataRow[dataColumns[6]].ToString(),
                        UserName = dataRow[dataColumns[7]].ToString(),
                        Password = dataRow[dataColumns[8]].ToString()
                    };
                }

                if (entity == null)
                {
                    return null;
                }

                return entity.ToModel();
            }
        }

        public FtpConfig GetFtpConfigByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            DbParameter[] parameters = new DbParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = SpParamsOfFtpConfig.Sp_Select_FtpConfigByName_Name,
                    Value = name
                }
            };

            using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfFtpConfig.Sp_Select_FtpConfigById, parameters))
            {
                FtpConfigEntity entity = null;

                if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows.Count != 0)
                {
                    DataRow dataRow = dataSet.Tables[0].Rows[0];
                    DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                    entity = new FtpConfigEntity()
                    {
                        Id = (int)dataRow[dataColumns[0]],
                        Name = dataRow[dataColumns[1]].ToString(),
                        Description = dataRow[dataColumns[2]].ToString(),
                        IP = dataRow[dataColumns[3]].ToString(),
                        Port = (int)dataRow[dataColumns[4]],
                        IsNeedAuthentication = (bool)dataRow[dataColumns[5]],
                        VirticalDir = dataRow[dataColumns[6]].ToString(),
                        UserName = dataRow[dataColumns[7]].ToString(),
                        Password = dataRow[dataColumns[8]].ToString()
                    };
                }

                if (entity == null)
                {
                    return null;
                }

                return entity.ToModel();
            }
        }

        #endregion
    }
}
