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
    public class NoteCommentDAL
    {
        private static NoteCommentDAL instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteCommentDAL()
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

        public static NoteCommentDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteCommentDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public NoteComment AddNoteComment(NoteComment noteComment)
        {
            try
            {
                if (noteComment == null)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteComment.Sp_Insert_NoteComment_NoteId,
                        Value = noteComment.NoteId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteComment.Sp_Insert_NoteComment_CreatorId,
                        Value = noteComment.CreatorId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNoteComment.Sp_Insert_NoteComment_CommentId,
                        Value = noteComment.CommentId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteComment.Sp_Insert_NoteComment, parameters))
                {
                    NoteCommentEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new NoteCommentEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            NoteId = (int)dataRow[dataColumns[1]],
                            CreatorId = (int)dataRow[dataColumns[2]],
                            CommentId = (int)dataRow[dataColumns[3]],
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

        public NoteComment GetNoteCommentById(int id)
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
                        ParameterName = SpParamsOfNoteComment.Sp_Select_NoteCommentById_Id,
                        Value = id
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteComment.Sp_Select_NoteCommentById, parameters))
                {
                    NoteCommentEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new NoteCommentEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            NoteId = (int)dataRow[dataColumns[1]],
                            CreatorId = (int)dataRow[dataColumns[2]],
                            CommentId = (int)dataRow[dataColumns[3]],
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

        public List<NoteComment> GetNoteCommentsByNoteId(int id)
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
                        ParameterName = SpParamsOfNoteComment.Sp_Select_NoteCommentByNoteId_NoteId,
                        Value = id
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNoteComment.Sp_Select_NoteCommentByNoteId, parameters))
                {
                    NoteCommentEntity entity = null;
                    List<NoteComment> noteComments = new List<NoteComment>();

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            entity = new NoteCommentEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                NoteId = (int)dataRow[dataColumns[1]],
                                CreatorId = (int)dataRow[dataColumns[2]],
                                CommentId = (int)dataRow[dataColumns[3]],
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                IsDeleted = (bool)dataRow[dataColumns[5]],
                                DeletedTime = (DateTime)dataRow[dataColumns[6]]
                            };

                            noteComments.Add(entity.ToModel());
                        }
                    }

                    return noteComments;
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
