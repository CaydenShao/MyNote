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
    public class NoteBrowsedRecordDAL
    {
        private static NoteBrowsedRecordDAL instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteBrowsedRecordDAL()
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

        public static NoteBrowsedRecordDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteBrowsedRecordDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public NoteBrowsedRecord AddNoteBrowsedRecord(int noteId, int userId)
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
                        ParameterName = SpParamsOfNoteBrowsedRecord.Sp_Add_NoteBrowsedRecord_NoteId,
                        Value = noteId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteBrowsedRecord.Sp_Add_NoteBrowsedRecord_UserId,
                        Value = userId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteApprovedRecord.Sp_IUGetApproved_NoteApprovedRecord, parameters))
                {
                    NoteBrowsedRecordEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new NoteBrowsedRecordEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            UserId = (int)dataRow[dataColumns[1]],
                            NoteId = (int)dataRow[dataColumns[2]],
                            BrowsedTime = (DateTime)dataRow[dataColumns[3]]
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

        public List<NoteBrowsedRecord> GetNoteBrowsedRecordsByNoteId(int noteId)
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
                        ParameterName = SpParamsOfNoteBrowsedRecord.Sp_Select_NoteBrowsedRecordsByNoteId_NoteId,
                        Value = noteId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteApprovedRecord.Sp_Select_NoteApprovedRecordsByNoteId, parameters))
                {
                    List<NoteBrowsedRecord> noteBrowsedRecords = new List<NoteBrowsedRecord>();

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteBrowsedRecordEntity entity = new NoteBrowsedRecordEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                UserId = (int)dataRow[dataColumns[1]],
                                NoteId = (int)dataRow[dataColumns[2]],
                                BrowsedTime = (DateTime)dataRow[dataColumns[3]]
                            };

                            noteBrowsedRecords.Add(entity.ToModel());
                        }
                    }

                    return noteBrowsedRecords;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NoteBrowsedRecord> GetNoteBrowsedRecordsByUserId(int userId)
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
                        ParameterName = SpParamsOfNoteBrowsedRecord.Sp_Select_NoteBrowsedRecordsByUserId_UserId,
                        Value = userId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteApprovedRecord.Sp_Select_NoteApprovedRecordsByUserId, parameters))
                {
                    List<NoteBrowsedRecord> noteBrowsedRecords = new List<NoteBrowsedRecord>();

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteBrowsedRecordEntity entity = new NoteBrowsedRecordEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                UserId = (int)dataRow[dataColumns[1]],
                                NoteId = (int)dataRow[dataColumns[2]],
                                BrowsedTime = (DateTime)dataRow[dataColumns[3]]
                            };

                            noteBrowsedRecords.Add(entity.ToModel());
                        }
                    }

                    return noteBrowsedRecords;
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
