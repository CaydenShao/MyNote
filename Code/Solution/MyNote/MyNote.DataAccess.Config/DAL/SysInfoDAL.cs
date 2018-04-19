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
    public class SysInfoDAL
    {
        private static SysInfoDAL instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private SysInfoDAL()
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

        public static SysInfoDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SysInfoDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public SysInfo AddSysInfo(SysInfo sysInfo)
        {
            if (sysInfo == null)
            {
                return null;
            }

            DbParameter[] parameters = new DbParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = SpParamsOfSysInfo.Sp_Insert_SysInfo_Name,
                    Value = sysInfo.Name
                },
                new SqlParameter()
                {
                    ParameterName = SpParamsOfSysInfo.Sp_Insert_SysInfo_Description,
                    Value = sysInfo.Description
                },
                new SqlParameter()
                {
                    ParameterName = SpParamsOfSysInfo.Sp_Insert_SysInfo_Detail,
                    Value = sysInfo.Detail
                }
            };

            using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfSysInfo.Sp_Insert_SysInfo, parameters))
            {
                SysInfoEntity entity = null;

                if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                {
                    DataRow dataRow = dataSet.Tables[0].Rows[0];
                    DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                    entity = new SysInfoEntity()
                    {
                        Id = (int)dataRow[dataColumns[0]],
                        Name = dataRow[dataColumns[1]].ToString(),
                        Description = dataRow[dataColumns[2]].ToString(),
                        Detail = dataRow[dataColumns[0]].ToString()
                    };
                }

                if (entity == null)
                {
                    return null;
                }

                return entity.ToModel();
            }
        }

        public SysInfo GetSysInfoById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            DbParameter[] parameters = new DbParameter[] 
            {
                new SqlParameter()
                {
                    ParameterName = SpParamsOfSysInfo.Sp_Select_SysInfoById_Id,
                    Value = id
                }
            };

            using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfSysInfo.Sp_Select_SysInfoById, parameters))
            {
                SysInfoEntity entity = null;

                if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                {
                    DataRow dataRow = dataSet.Tables[0].Rows[0];
                    DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                    entity = new SysInfoEntity()
                    {
                        Id = (int)dataRow[dataColumns[0]],
                        Name = dataRow[dataColumns[1]].ToString(),
                        Description = dataRow[dataColumns[2]].ToString(),
                        Detail = dataRow[dataColumns[3]].ToString()
                    };
                }

                if (entity == null)
                {
                    return null;
                }

                return entity.ToModel();
            }
        }

        public SysInfo GetSysInfoByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            DbParameter[] parameters = new DbParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = SpParamsOfSysInfo.Sp_Select_SysInfoByName_Name,
                    Value = name
                }
            };

            using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfSysInfo.Sp_Select_SysInfoByName, parameters))
            {
                SysInfoEntity entity = null;

                if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                {
                    DataRow dataRow = dataSet.Tables[0].Rows[0];
                    DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                    entity = new SysInfoEntity()
                    {
                        Id = (int)dataRow[dataColumns[0]],
                        Name = dataRow[dataColumns[1]].ToString(),
                        Description = dataRow[dataColumns[2]].ToString(),
                        Detail = dataRow[dataColumns[3]].ToString()
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
