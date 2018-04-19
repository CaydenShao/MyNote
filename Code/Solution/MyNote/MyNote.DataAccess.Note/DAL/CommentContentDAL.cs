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
    public class CommentContentDAL
    {
        private static CommentContentDAL instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private CommentContentDAL()
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

        public static CommentContentDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CommentContentDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public NoteCommentContent AddCommentContent(NoteCommentContent commentContent)
        {
            try
            {
                if (commentContent == null)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfCommentContent.Sp_Insert_CommentContent_CommentId,
                        Value = commentContent.CommentId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfCommentContent.Sp_Insert_CommentContent_Type,
                        Value = commentContent.Type
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfCommentContent.Sp_Insert_CommentContent_Content,
                        Value = commentContent.Content
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfCommentContent.Sp_Insert_CommentContent, parameters))
                {
                    CommentContentEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new CommentContentEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            CommentId = (int)dataRow[dataColumns[1]],
                            Type = (int)dataRow[dataColumns[2]],
                            Content = (string)dataRow[dataColumns[3]],
                            CreateTime = (DateTime)dataRow[dataColumns[4]]
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

        public NoteCommentContent GetCommentContentById(int id)
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
                        ParameterName = SpParamsOfCommentContent.Sp_Select_CommentContentById_Id,
                        Value = id
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfCommentContent.Sp_Select_CommentContentById, parameters))
                {
                    CommentContentEntity entity = null;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new CommentContentEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            CommentId = (int)dataRow[dataColumns[1]],
                            Type = (int)dataRow[dataColumns[2]],
                            Content = (string)dataRow[dataColumns[3]],
                            CreateTime = (DateTime)dataRow[dataColumns[4]]
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

        public List<NoteCommentContent> GetCommentContentByCommentId(int commentId)
        {
            try
            {
                if (commentId <= 0)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfCommentContent.Sp_Select_CommentContentByCommentId_CommentId,
                        Value = commentId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfCommentContent.Sp_Select_CommentContentByCommentId, parameters))
                {
                    List<NoteCommentContent> commentContents = new List<NoteCommentContent>();

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            CommentContentEntity entity = new CommentContentEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                CommentId = (int)dataRow[dataColumns[1]],
                                Type = (int)dataRow[dataColumns[2]],
                                Content = (string)dataRow[dataColumns[3]],
                                CreateTime = (DateTime)dataRow[dataColumns[4]]
                            };

                            commentContents.Add(entity.ToModel());
                        }
                    }

                    return commentContents;
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
