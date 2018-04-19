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
    public class NoteContentDAL
    {
        private static NoteContentDAL instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteContentDAL()
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

        public static NoteContentDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteContentDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public NoteContent AddNoteContent(NoteContent noteContent)
        {
            try
            {
                if (noteContent == null)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteContent.Sp_Insert_NoteContent_NoteId,
                        Value = noteContent.NoteId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteContent.Sp_Insert_NoteContent_Type,
                        Value = noteContent.Type
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteContent.Sp_Insert_NoteContent_Content,
                        Value = noteContent.Content
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteContent.Sp_Insert_NoteContent, parameters))
                {
                    NoteContentEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new NoteContentEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            NoteId = (int)dataRow[dataColumns[1]],
                            Type = (int)dataRow[dataColumns[2]],
                            Content = dataRow[dataColumns[3]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[4]],
                            IsDeleted = (bool)dataRow[dataColumns[5]],
                            DeletedTime = (DateTime)dataRow[dataColumns[6]]
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

        public NoteContent GetNoteCommentById(int id)
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
                        ParameterName = SpParamsOfNoteContent.Sp_Select_NoteContentById_Id,
                        Value = id
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteContent.Sp_Select_NoteContentById, parameters))
                {
                    NoteContentEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new NoteContentEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            NoteId = (int)dataRow[dataColumns[1]],
                            Type = (int)dataRow[dataColumns[2]],
                            Content = dataRow[dataColumns[3]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[4]],
                            IsDeleted = (bool)dataRow[dataColumns[5]],
                            DeletedTime = (DateTime)dataRow[dataColumns[6]]
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

        public List<NoteContent> GetNoteCommentByNoteId(int id)
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
                        ParameterName = SpParamsOfNoteContent.Sp_Select_NoteContentByNoteId_NoteId,
                        Value = id
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteContent.Sp_Select_NoteContentByNoteId, parameters))
                {
                    NoteContentEntity entity = null;
                    List<NoteContent> noteContents = new List<NoteContent>();

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            entity = new NoteContentEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                NoteId = (int)dataRow[dataColumns[1]],
                                Type = (int)dataRow[dataColumns[2]],
                                Content = dataRow[dataColumns[3]].ToString(),
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                IsDeleted = (bool)dataRow[dataColumns[5]],
                                DeletedTime = (DateTime)dataRow[dataColumns[6]]
                            };

                            noteContents.Add(entity.ToModel());
                        }
                    }

                    return noteContents;
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
