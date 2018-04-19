using MyNote.Contracts.DataContracts.Notes;
using MyNote.DataAccess.Common;
using MyNote.DataAccess.Notes.Extensions;
using MyNote.DataAccess.Notes.Entities;
using MyNote.DataAccess.Notes.ProcedureContainer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Notes.DAL
{
    public class NoteApprovedRecordDAL
    {
        private static NoteApprovedRecordDAL instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteApprovedRecordDAL()
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

        public static NoteApprovedRecordDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteApprovedRecordDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public NoteApprovedRecord AddOrUpdateToNotCancel(int noteId, int userId)
        {
            try
            {
                if (noteId <= 0 || userId <= 0)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteApprovedRecord.Sp_IUGetApproved_NoteApprovedRecord_NoteId,
                        Value = noteId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteApprovedRecord.Sp_IUGetApproved_NoteApprovedRecord_UserId,
                        Value = userId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteApprovedRecord.Sp_IUGetApproved_NoteApprovedRecord, parameters))
                {
                    NoteApprovedRecordEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new NoteApprovedRecordEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            UserId = (int)dataRow[dataColumns[1]],
                            NoteId = (int)dataRow[dataColumns[2]],
                            ApprovedTime = (DateTime)dataRow[dataColumns[3]],
                            IsCanceled = (bool)dataRow[dataColumns[4]],
                            CanceledTime = (DateTime)dataRow[dataColumns[5]]
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

        public NoteApprovedRecord GetCanceled(int noteId, int userId)
        {
            try
            {
                if (noteId <= 0 || userId <= 0)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteApprovedRecord.Sp_UCancel_NoteApprovedRecord_NoteId,
                        Value = noteId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteApprovedRecord.Sp_UCancel_NoteApprovedRecord_UserId,
                        Value = userId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteApprovedRecord.Sp_UCancel_NoteApprovedRecord, parameters))
                {
                    NoteApprovedRecordEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new NoteApprovedRecordEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            UserId = (int)dataRow[dataColumns[1]],
                            NoteId = (int)dataRow[dataColumns[2]],
                            ApprovedTime = (DateTime)dataRow[dataColumns[3]],
                            IsCanceled = (bool)dataRow[dataColumns[4]],
                            CanceledTime = (DateTime)dataRow[dataColumns[5]]
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

        public List<NoteApprovedRecord> GetNoteApprovedRecordsByNoteId(int noteId)
        {
            try
            {
                if (noteId <= 0)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteApprovedRecord.Sp_Select_NoteApprovedRecordsByNoteId_NoteId,
                        Value = noteId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteApprovedRecord.Sp_Select_NoteApprovedRecordsByNoteId, parameters))
                {
                    List<NoteApprovedRecord> noteApprovedRecords = new List<NoteApprovedRecord>();

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteApprovedRecordEntity entity = new NoteApprovedRecordEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                UserId = (int)dataRow[dataColumns[1]],
                                NoteId = (int)dataRow[dataColumns[2]],
                                ApprovedTime = (DateTime)dataRow[dataColumns[3]],
                                IsCanceled = (bool)dataRow[dataColumns[4]],
                                CanceledTime = (DateTime)dataRow[dataColumns[5]]
                            };

                            noteApprovedRecords.Add(entity.ToModel());
                        }
                    }

                    return noteApprovedRecords;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NoteApprovedRecord> GetNoteApprovedRecordsByUserId(int userId)
        {
            try
            {
                if (userId <= 0)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteApprovedRecord.Sp_Select_NoteApprovedRecordsByUserId_UserId,
                        Value = userId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteApprovedRecord.Sp_Select_NoteApprovedRecordsByUserId, parameters))
                {
                    List<NoteApprovedRecord> noteApprovedRecords = new List<NoteApprovedRecord>();

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteApprovedRecordEntity entity = new NoteApprovedRecordEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                UserId = (int)dataRow[dataColumns[1]],
                                NoteId = (int)dataRow[dataColumns[2]],
                                ApprovedTime = (DateTime)dataRow[dataColumns[3]],
                                IsCanceled = (bool)dataRow[dataColumns[4]],
                                CanceledTime = (DateTime)dataRow[dataColumns[5]]
                            };

                            noteApprovedRecords.Add(entity.ToModel());
                        }
                    }

                    return noteApprovedRecords;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NoteApprovedRecord GetNoteApprovedRecordByNoteIdAndUserId(int noteId, int userId)
        {
            try
            {
                if (userId <= 0 || noteId <= 0)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteApprovedRecord.Sp_Select_NoteApprovedRecordByNoteIdAndUserId_NoteId,
                        Value = noteId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteApprovedRecord.Sp_Select_NoteApprovedRecordByNoteIdAndUserId_UserId,
                        Value = userId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteApprovedRecord.Sp_Select_NoteApprovedRecordByNoteIdAndUserId, parameters))
                {
                    NoteApprovedRecordEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            entity = new NoteApprovedRecordEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                UserId = (int)dataRow[dataColumns[1]],
                                NoteId = (int)dataRow[dataColumns[2]],
                                ApprovedTime = (DateTime)dataRow[dataColumns[3]],
                                IsCanceled = (bool)dataRow[dataColumns[4]],
                                CanceledTime = (DateTime)dataRow[dataColumns[5]]
                            };
                        }
                    }

                    return entity == null ? null : entity.ToModel();
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
