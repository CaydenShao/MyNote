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
    public class VerificationDAL
    {
        private static VerificationDAL instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private VerificationDAL()
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

        public static VerificationDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new VerificationDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public Verification AddVerification(Verification verification)
        {
            try
            {
                if (verification == null)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[] 
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfVerification.Sp_Insert_Verification_PhoneNumber,
                        Value = verification.PhoneNumber
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfVerification.Sp_Insert_Verification_Code,
                        Value = verification.Code
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfVerification.Sp_Put_Verification, parameters))
                {
                    VerificationEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new VerificationEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            PhoneNumber = dataRow[dataColumns[1]].ToString(),
                            StartTime = (DateTime)dataRow[dataColumns[2]],
                            Code = dataRow[dataColumns[3]].ToString()
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

        public Verification GetVerificationById(int id)
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
                        ParameterName = SpParamsOfVerification.Sp_Select_VerificationById_Id,
                        Value = id
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfVerification.Sp_Select_VerificationById, parameters))
                {
                    VerificationEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new VerificationEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            PhoneNumber = dataRow[dataColumns[1]].ToString(),
                            StartTime = (DateTime)dataRow[dataColumns[2]],
                            Code = dataRow[dataColumns[3]].ToString()
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

        public Verification GetVerificationByPhoneNumber(string phoneNumber)
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
                        ParameterName = SpParamsOfVerification.Sp_Select_VerificationByPhoneNumber_PhoneNumber,
                        Value = phoneNumber
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfVerification.Sp_Select_VerificationByPhoneNumber, parameters))
                {
                    VerificationEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new VerificationEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            PhoneNumber = dataRow[dataColumns[1]].ToString(),
                            StartTime = (DateTime)dataRow[dataColumns[2]],
                            Code = dataRow[dataColumns[3]].ToString()
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
