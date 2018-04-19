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
    public class NoteDAL
    {
        private static NoteDAL instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteDAL()
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

        public static NoteDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Public methods

        public Note AddNote(Note note)
        {
            try
            {
                if (note == null)
                {
                    return null;
                }

                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Insert_Note_AuthorId,
                        Value = note.AuthorId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Insert_Note_IsShared,
                        Value = note.IsShared
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Insert_Note_Title,
                        Value = note.Title
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Insert_Note_Remark,
                        Value = note.Remark
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Insert_Note, parameters))
                {
                    NoteEntity entity = null;
                    int browsedTimes = 0;
                    int aprovedTimes = 0;
                    int commentCount = 0;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new NoteEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            AuthorId = (int)dataRow[dataColumns[1]],
                            Title = dataRow[dataColumns[2]].ToString(),
                            Remark = dataRow[dataColumns[3]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[4]],
                            LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                            IsShared = (bool)dataRow[dataColumns[6]],
                            IsDeleted = (bool)dataRow[dataColumns[7]],
                            DeletedTime = (DateTime)dataRow[dataColumns[8]]
                        };

                        browsedTimes = (int)dataRow[dataColumns[9]];
                        aprovedTimes = (int)dataRow[dataColumns[10]];
                        commentCount = (int)dataRow[dataColumns[11]];
                    }

                    if (entity == null)
                    {
                        return null;
                    }

                    Note model = entity.ToModel();
                    model.ApprovedTimes = aprovedTimes;
                    model.BrowsedTimes = browsedTimes;
                    model.CommentCount = commentCount;
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Note GetNoteById(int id)
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
                        ParameterName = SpParamsOfNote.Sp_Select_NoteById_Id,
                        Value = id
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Select_NoteById, parameters))
                {
                    NoteEntity entity = null;
                    int browsedTimes = 0;
                    int aprovedTimes = 0;
                    int commentCount = 0;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        entity = new NoteEntity()
                        {
                            Id = (int)dataRow[dataColumns[0]],
                            AuthorId = (int)dataRow[dataColumns[1]],
                            Title = dataRow[dataColumns[2]].ToString(),
                            Remark = dataRow[dataColumns[3]].ToString(),
                            CreateTime = (DateTime)dataRow[dataColumns[4]],
                            LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                            IsShared = (bool)dataRow[dataColumns[6]],
                            IsDeleted = (bool)dataRow[dataColumns[7]],
                            DeletedTime = (DateTime)dataRow[dataColumns[8]]
                        };

                        browsedTimes = (int)dataRow[dataColumns[9]];
                        aprovedTimes = (int)dataRow[dataColumns[10]];
                        commentCount = (int)dataRow[dataColumns[11]];
                    }

                    if (entity == null)
                    {
                        return null;
                    }

                    Note model = entity.ToModel();
                    model.ApprovedTimes = aprovedTimes;
                    model.BrowsedTimes = browsedTimes;
                    model.CommentCount = commentCount;
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Note> GetNoteByAuthorId(int id)
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
                        ParameterName = SpParamsOfNote.Sp_Select_NoteByAuthorId_AuthorId,
                        Value = id
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Select_NoteByAuthorId, parameters))
                {
                    List<Note> notes = new List<Note>();

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteEntity entity = new NoteEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                AuthorId = (int)dataRow[dataColumns[1]],
                                Title = dataRow[dataColumns[2]].ToString(),
                                Remark = dataRow[dataColumns[3]].ToString(),
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                                IsShared = (bool)dataRow[dataColumns[6]],
                                IsDeleted = (bool)dataRow[dataColumns[7]],
                                DeletedTime = (DateTime)dataRow[dataColumns[8]]
                            };

                            Note model = entity.ToModel();
                            model.BrowsedTimes = (int)dataRow[dataColumns[9]];
                            model.ApprovedTimes = (int)dataRow[dataColumns[10]];
                            model.CommentCount = (int)dataRow[dataColumns[11]];
                            notes.Add(model);
                        }
                    }

                    return notes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNoteAndContents(Note note, List<NoteContent> noteContents)
        {
            try
            {
                using (DbConnection connection = DbHelper.Instance.Provider.CreateConnection())
                {
                    connection.ConnectionString = DbHelper.Instance.ConnectionString;
                    connection.Open();

                    using (DbTransaction trans = connection.BeginTransaction())
                    {
                        try
                        {
                            using (DbDataAdapter sqlDA = DbHelper.Instance.Provider.CreateDataAdapter())
                            {
                                #region 获取添加成功后返回的NoteEntity，包括生产的ID

                                DbParameter[] parameters = new DbParameter[]
                                {
                                    new SqlParameter()
                                    {
                                        ParameterName = SpParamsOfNote.Sp_Insert_Note_AuthorId,
                                        Value = note.AuthorId
                                    },
                                    new SqlParameter()
                                    {
                                        ParameterName = SpParamsOfNote.Sp_Insert_Note_Title,
                                        Value = note.Title
                                    },
                                    new SqlParameter()
                                    {
                                        ParameterName = SpParamsOfNote.Sp_Insert_Note_IsShared,
                                        Value = note.IsShared
                                    },
                                    new SqlParameter()
                                    {
                                        ParameterName = SpParamsOfNote.Sp_Insert_Note_Remark,
                                        Value = note.Remark
                                    }
                                };

                                Note returnNote = null;

                                using (DataSet dataSet = new DataSet())
                                {
                                    sqlDA.SelectCommand = DbHelper.Instance.BuildQueryCommand(connection, SpNamesOfNote.Sp_Insert_Note, parameters);
                                    sqlDA.SelectCommand.Transaction = trans;
                                    sqlDA.Fill(dataSet);
                                    sqlDA.SelectCommand.Parameters.Clear();
                                    

                                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                                    {
                                        DataRow dataRow = dataSet.Tables[0].Rows[0];
                                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                                        NoteEntity noteEntity = new NoteEntity()
                                        {
                                            Id = (int)dataRow[dataColumns[0]],
                                            AuthorId = (int)dataRow[dataColumns[1]],
                                            Title = dataRow[dataColumns[2]].ToString(),
                                            Remark = dataRow[dataColumns[3]].ToString(),
                                            CreateTime = (DateTime)dataRow[dataColumns[4]],
                                            LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                                            IsShared = (bool)dataRow[dataColumns[6]],
                                            IsDeleted = (bool)dataRow[dataColumns[7]],
                                            DeletedTime = (DateTime)dataRow[dataColumns[8]]
                                        };

                                        returnNote = noteEntity.ToModel();
                                        returnNote.BrowsedTimes = (int)dataRow[dataColumns[9]];
                                        returnNote.ApprovedTimes = (int)dataRow[dataColumns[10]];
                                        returnNote.CommentCount = (int)dataRow[dataColumns[11]];
                                    }
                                    else
                                    {
                                        // 添加失败，回滚事务
                                        trans.Rollback();
                                        return false;
                                    }
                                }

                                #endregion

                                using (DataSet dataSet = new DataSet())
                                {

                                    #region 添加NoteContent

                                    if (noteContents != null)
                                    {
                                        List<NoteContentEntity> noteContentEntities = new List<NoteContentEntity>();

                                        foreach (NoteContent noteContent in noteContents)
                                        {
                                            parameters = new DbParameter[]
                                            {
                                            new SqlParameter()
                                            {
                                                ParameterName = SpParamsOfNoteContent.Sp_Insert_NoteContent_NoteId,
                                                Value = returnNote.Id
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

                                            sqlDA.SelectCommand = DbHelper.Instance.BuildQueryCommand(connection, SpNamesOfNoteContent.Sp_Insert_NoteContent, parameters);
                                            sqlDA.SelectCommand.Transaction = trans;
                                            sqlDA.Fill(dataSet);
                                            sqlDA.SelectCommand.Parameters.Clear();
                                            NoteContentEntity noteContentEntity = null;

                                            if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                                            {
                                                DataRow dataRow = dataSet.Tables[0].Rows[0];
                                                DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                                                noteContentEntity = new NoteContentEntity()
                                                {
                                                    Id = (int)dataRow[dataColumns[0]],
                                                    NoteId = (int)dataRow[dataColumns[1]],
                                                    Type = (int)dataRow[dataColumns[2]],
                                                    Content = dataRow[dataColumns[3]].ToString(),
                                                    CreateTime = (DateTime)dataRow[dataColumns[4]],
                                                    IsDeleted = (bool)dataRow[dataColumns[5]],
                                                    DeletedTime = (DateTime)dataRow[dataColumns[6]]
                                                };

                                                noteContentEntities.Add(noteContentEntity);
                                            }
                                            else
                                            {
                                                // 添加失败，回滚事务
                                                trans.Rollback();
                                                return false;
                                            }

                                            dataSet.Clear();
                                        }

                                        returnNote.CopyTo(note);

                                        for (int i = 0; i < noteContentEntities.Count; i++)
                                        {
                                            noteContentEntities[i].CopyTo(noteContents[i]);
                                        }
                                    }

                                    #endregion
                                }
                            }

                            trans.Commit();
                            return true;
                        }
                        catch(Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NoteBrowsedRecord NoteGetBrowsed(int noteId, int userId)
        {
            try
            {
                if (noteId <= 0 || userId <= 0)
                {
                    return null;
                }

                DbParameter[] parameters = new SqlParameter[] 
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Update_NoteGetBrowsed_NoteId,
                        Value = noteId
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Update_NoteGetBrowsed_UserId,
                        Value = userId
                    }
                };

                NoteBrowsedRecordEntity entity = null;

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Update_NoteGetBrowsed, parameters))
                {
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
                }

                return entity == null ? null : entity.ToModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Note> SearchByAuthorId(int pageSize, int pageIndex, int authorId, out int totalRows)
        {
            try
            {
                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByAuthorId_PageSize,
                        Value = pageSize
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByAuthorId_PageIndex,
                        Value = pageIndex
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByAuthorId_AuthorId,
                        Value = authorId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Select_NoteSearchByAuthorId, parameters))
                {
                    List<Note> notes = new List<Note>();
                    int total = 0;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteEntity entity = new NoteEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                AuthorId = (int)dataRow[dataColumns[1]],
                                Title = dataRow[dataColumns[2]].ToString(),
                                Remark = dataRow[dataColumns[3]].ToString(),
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                                IsShared = (bool)dataRow[dataColumns[6]],
                                IsDeleted = (bool)dataRow[dataColumns[7]],
                                DeletedTime = (DateTime)dataRow[dataColumns[8]]
                            };

                            Note model = entity.ToModel();
                            model.BrowsedTimes = (int)dataRow[dataColumns[9]];
                            model.ApprovedTimes = (int)dataRow[dataColumns[10]];
                            model.CommentCount = (int)dataRow[dataColumns[11]];
                            total = int.Parse(dataRow[dataColumns[12]].ToString());
                            notes.Add(model);
                        }
                    }

                    totalRows = total;
                    return notes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Note> SearchByRemark(int pageSize, int pageIndex, string searchStr, out int totalRows)
        {
            try
            {
                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByRemark_PageSize,
                        Value = pageSize
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByRemark_PageIndex,
                        Value = pageIndex
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByRemark_SearchStr,
                        Value = searchStr
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Select_NoteSearchByRemark, parameters))
                {
                    List<Note> notes = new List<Note>();
                    int total = 0;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteEntity entity = new NoteEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                AuthorId = (int)dataRow[dataColumns[1]],
                                Title = dataRow[dataColumns[2]].ToString(),
                                Remark = dataRow[dataColumns[3]].ToString(),
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                                IsShared = (bool)dataRow[dataColumns[6]],
                                IsDeleted = (bool)dataRow[dataColumns[7]],
                                DeletedTime = (DateTime)dataRow[dataColumns[8]]
                            };

                            Note model = entity.ToModel();
                            model.BrowsedTimes = (int)dataRow[dataColumns[9]];
                            model.ApprovedTimes = (int)dataRow[dataColumns[10]];
                            model.CommentCount = (int)dataRow[dataColumns[11]];
                            total = int.Parse(dataRow[dataColumns[12]].ToString());
                            notes.Add(model);
                        }
                    }

                    totalRows = total;
                    return notes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Note> SearchByRemarkAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows)
        {
            try
            {
                DbParameter[] parameters = new DbParameter[] 
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByRemarkAndAuthorId_PageSize,
                        Value = pageSize
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByRemarkAndAuthorId_PageIndex,
                        Value = pageIndex
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByRemarkAndAuthorId_SearchStr,
                        Value = searchStr
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByRemarkAndAuthorId_AuthorId,
                        Value = authorId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Select_NoteSearchByRemarkAndAuthorId, parameters))
                {
                    List<Note> notes = new List<Note>();
                    int total = 0;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteEntity entity = new NoteEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                AuthorId = (int)dataRow[dataColumns[1]],
                                Title = dataRow[dataColumns[2]].ToString(),
                                Remark = dataRow[dataColumns[3]].ToString(),
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                                IsShared = (bool)dataRow[dataColumns[6]],
                                IsDeleted = (bool)dataRow[dataColumns[7]],
                                DeletedTime = (DateTime)dataRow[dataColumns[8]]
                            };

                            Note model = entity.ToModel();
                            model.BrowsedTimes = (int)dataRow[dataColumns[9]];
                            model.ApprovedTimes = (int)dataRow[dataColumns[10]];
                            model.CommentCount = (int)dataRow[dataColumns[11]];
                            total = int.Parse(dataRow[dataColumns[12]].ToString());
                            notes.Add(model);
                        }
                    }

                    totalRows = total;
                    return notes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Note> SearchByTitle(int pageSize, int pageIndex, string searchStr, out int totalRows)
        {
            try
            {
                DbParameter[] parameters = new DbParameter[] 
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTitle_SearchStr,
                        Value = pageSize
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTitle_PageIndex,
                        Value = pageIndex
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTitle_SearchStr,
                        Value = searchStr
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Select_NoteSearchByTitle, parameters))
                {
                    List<Note> notes = new List<Note>();
                    int total = 0;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteEntity entity = new NoteEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                AuthorId = (int)dataRow[dataColumns[1]],
                                Title = dataRow[dataColumns[2]].ToString(),
                                Remark = dataRow[dataColumns[3]].ToString(),
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                                IsShared = (bool)dataRow[dataColumns[6]],
                                IsDeleted = (bool)dataRow[dataColumns[7]],
                                DeletedTime = (DateTime)dataRow[dataColumns[8]]
                            };

                            Note model = entity.ToModel();
                            model.BrowsedTimes = (int)dataRow[dataColumns[9]];
                            model.ApprovedTimes = (int)dataRow[dataColumns[10]];
                            model.CommentCount = (int)dataRow[dataColumns[11]];
                            total = int.Parse(dataRow[dataColumns[12]].ToString());
                            notes.Add(model);
                        }
                    }

                    totalRows = total;
                    return notes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Note> SearchByTitleAndAuthorId(int pageSize, int pageIndex, string searchStr, int authorId, out int totalRows)
        {
            try
            {
                DbParameter[] parameters = new DbParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTitleAndAuthorId_PageSize,
                        Value = pageSize
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTitleAndAuthorId_PageIndex,
                        Value = pageIndex
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTitleAndAuthorId_SearchStr,
                        Value = searchStr
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTitleAndAuthorId_AuthorId,
                        Value = authorId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Select_NoteSearchByTitleAndAuthorId, parameters))
                {
                    List<Note> notes = new List<Note>();
                    int total = 0;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteEntity entity = new NoteEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                AuthorId = (int)dataRow[dataColumns[1]],
                                Title = dataRow[dataColumns[2]].ToString(),
                                Remark = dataRow[dataColumns[3]].ToString(),
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                                IsShared = (bool)dataRow[dataColumns[6]],
                                IsDeleted = (bool)dataRow[dataColumns[7]],
                                DeletedTime = (DateTime)dataRow[dataColumns[8]]
                            };

                            Note model = entity.ToModel();
                            model.BrowsedTimes = (int)dataRow[dataColumns[9]];
                            model.ApprovedTimes = (int)dataRow[dataColumns[10]];
                            model.CommentCount = (int)dataRow[dataColumns[11]];
                            total = int.Parse(dataRow[dataColumns[12]].ToString());
                            notes.Add(model);
                        }
                    }

                    totalRows = total;
                    return notes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Note> SearchByTimeSpan(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, out int totalRows)
        {
            try
            {
                DbParameter[] parameters = new DbParameter[] 
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTimeSpan_PageSize,
                        Value = pageSize
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTimeSpan_PageIndex,
                        Value = pageIndex
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTimeSpan_StartTime,
                        Value = startTime
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTimeSpan_EndTime,
                        Value = endTime
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Select_NoteSearchByTimeSpan, parameters))
                {
                    List<Note> notes = new List<Note>();
                    int total = 0;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteEntity entity = new NoteEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                AuthorId = (int)dataRow[dataColumns[1]],
                                Title = dataRow[dataColumns[2]].ToString(),
                                Remark = dataRow[dataColumns[3]].ToString(),
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                                IsShared = (bool)dataRow[dataColumns[6]],
                                IsDeleted = (bool)dataRow[dataColumns[7]],
                                DeletedTime = (DateTime)dataRow[dataColumns[8]]
                            };

                            Note model = entity.ToModel();
                            model.BrowsedTimes = (int)dataRow[dataColumns[9]];
                            model.ApprovedTimes = (int)dataRow[dataColumns[10]];
                            model.CommentCount = (int)dataRow[dataColumns[11]];
                            total = int.Parse(dataRow[dataColumns[12]].ToString());
                            notes.Add(model);
                        }
                    }

                    totalRows = total;
                    return notes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Note> SearchByTimeSpanAndAuthorId(int pageSize, int pageIndex, DateTime startTime, DateTime endTime, int authorId, out int totalRows)
        {
            try
            {
                DbParameter[] parameters = new DbParameter[] 
                {
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTimeSpanAndAuthorId_PageSize, 
                        Value = pageSize
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTimeSpanAndAuthorId_PageIndex,
                        Value = pageIndex
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTimeSpanAndAuthorId_StartTime,
                        Value = startTime
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTimeSpanAndAuthorId_EndTime,
                        Value = endTime
                    },
                    new SqlParameter()
                    {
                        ParameterName = SpParamsOfNote.Sp_Select_NoteSearchByTimeSpanAndAuthorId_AuthorId,
                        Value = authorId
                    }
                };

                using (DataSet dataSet = DbHelper.Instance.RunProcedureGetDataSet(SpNamesOfNote.Sp_Select_NoteSearchByTimeSpanAndAuthorId, parameters))
                {
                    List<Note> notes = new List<Note>();
                    int total = 0;

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRowCollection dataRows = dataSet.Tables[0].Rows;
                        DataColumnCollection dataColumns = dataSet.Tables[0].Columns;

                        foreach (DataRow dataRow in dataRows)
                        {
                            NoteEntity entity = new NoteEntity()
                            {
                                Id = (int)dataRow[dataColumns[0]],
                                AuthorId = (int)dataRow[dataColumns[1]],
                                Title = dataRow[dataColumns[2]].ToString(),
                                Remark = dataRow[dataColumns[3]].ToString(),
                                CreateTime = (DateTime)dataRow[dataColumns[4]],
                                LastBrowsedTime = (DateTime)dataRow[dataColumns[5]],
                                IsShared = (bool)dataRow[dataColumns[6]],
                                IsDeleted = (bool)dataRow[dataColumns[7]],
                                DeletedTime = (DateTime)dataRow[dataColumns[8]]
                            };

                            Note model = entity.ToModel();
                            model.BrowsedTimes = (int)dataRow[dataColumns[9]];
                            model.ApprovedTimes = (int)dataRow[dataColumns[10]];
                            model.CommentCount = (int)dataRow[dataColumns[11]];
                            total = int.Parse(dataRow[dataColumns[12]].ToString());
                            notes.Add(model);
                        }
                    }

                    totalRows = total;
                    return notes;
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
