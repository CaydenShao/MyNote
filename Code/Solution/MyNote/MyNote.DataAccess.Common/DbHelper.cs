using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Data;

namespace MyNote.DataAccess.Common
{
    public class DbHelper
    {
        private static DbHelper instance = null;
        private static object syncRoot = new object();
        protected static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private DbProviderFactory provider;

        #region Constructors

        private DbHelper()
        {
            this.provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["ConnectionString"].ProviderName);
        }

        #endregion

        #region Properties

        public static DbHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DbHelper();
                        }
                    }
                }

                return instance;
            }
        }

        public static Object SyncRoot
        {
            get
            {
                return syncRoot;
            }
        }

        public DbProviderFactory Provider
        {
            get
            {
                return this.provider;
            }
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        #endregion

        #region Public methods

        public void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction trans, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.CommandType = CommandType.Text;//cmdType;

            if (cmdParms != null)
            {
                foreach (DbParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        public DbCommand BuildQueryCommand(DbConnection connection, string storedProcName, DbParameter[] parameters)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            DbCommand command = provider.CreateCommand();
            command.CommandText = storedProcName;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        #region 执行简单的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string sqlString)
        {
            using (DbConnection connection = this.provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = this.provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sqlString;
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>        
        public void ExecuteSqlTran(List<string> sqlStringList)
        {
            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = conn;

                    using (DbTransaction tx = conn.BeginTransaction())
                    {
                        cmd.Transaction = tx;

                        try
                        {
                            foreach (string sqlStr in sqlStringList)
                            {
                                if (sqlStr.Trim().Length > 1)
                                {
                                    cmd.CommandText = sqlStr;
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            tx.Commit();
                        }
                        catch (DbException ex)
                        {
                            tx.Rollback();
                            conn.Close();
                            conn.Dispose();
                            throw ex;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string sqlString)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sqlString;

                    connection.Open();
                    object obj = cmd.ExecuteScalar();

                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，通过SqlDataReader读取查询结果
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>查询结果</returns>
        public static T ExecuteReader<T>(string sqlString, Func<DbDataReader, T> reader)
        {
            using (DbConnection connection = Instance.Provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = Instance.Provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sqlString;
                    connection.Open();

                    using (DbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        return reader(myReader);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string sqlString)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sqlString;
                    DataSet ds = new DataSet();
                    DbDataAdapter adapter = provider.CreateDataAdapter();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds, "ds");
                    return ds;
                }
            }
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string sqlString, DbParameter[] cmdParms)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sqlString;
                    PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public void ExecuteSqlTran(Hashtable sqlStringList)
        {
            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                using (DbTransaction trans = conn.BeginTransaction())
                {
                    using (DbCommand cmd = provider.CreateCommand())
                    {
                        try
                        {
                            //循环
                            foreach (DictionaryEntry myDE in sqlStringList)
                            {
                                string cmdText = myDE.Key.ToString();
                                DbParameter[] cmdParms = (DbParameter[])myDE.Value;
                                PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }

                            trans.Commit();
                        }
                        catch (DbException ex)
                        {
                            trans.Rollback();
                            conn.Close();
                            conn.Dispose();
                            throw ex;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）,返回首行首列的值;
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string sqlString, DbParameter[] cmdParms)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = provider.CreateCommand())
                {
                    PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，通过SqlDataReader读取查询结果
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>查询结果</returns>
        public static T ExecuteReader<T>(string sqlString, DbParameter[] cmdParms, Func<DbDataReader, T> reader)
        {
            using (DbConnection connection = Instance.Provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = Instance.Provider.CreateCommand())
                {
                    Instance.PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                    using (DbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        cmd.Parameters.Clear();
                        return reader(myReader);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string sqlString, DbParameter[] cmdParms)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = provider.CreateCommand())
                {
                    using (DbDataAdapter da = provider.CreateDataAdapter())
                    {
                        PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                        return ds;
                    }
                }
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程;
        /// </summary>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">所需要的参数</param>
        /// <returns>返回受影响的行数</returns>
        public int RunProcedureExecuteSql(string storeProcName, DbParameter[] parameters)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = BuildQueryCommand(connection, storeProcName, parameters))
                {
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
            }
        }

        /// <summary>
        /// 执行存储过程,返回首行首列的值
        /// </summary>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>返回首行首列的值</returns>
        public Object RunProcedureGetSingle(string storeProcName, DbParameter[] parameters)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand cmd = BuildQueryCommand(connection, storeProcName, parameters))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
            }
        }

        /// <summary>
        /// 执行存储过程，通过SqlDataReader读取查询结果
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>查询结果</returns>
        public static T RunProcedureGetDataReader<T>(string storedProcName, DbParameter[] parameters, Func<DbDataReader, T> reader)
        {
            using (DbConnection connection = Instance.Provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                DbDataReader returnReader;

                using (DbCommand cmd = Instance.BuildQueryCommand(connection, storedProcName, parameters))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (returnReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        cmd.Parameters.Clear();
                        return reader(returnReader);
                    }
                }
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedureGetDataSet(string storedProcName, DbParameter[] parameters)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                DataSet dataSet = new DataSet();

                using (DbDataAdapter sqlDA = provider.CreateDataAdapter())
                {
                    sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.Fill(dataSet);
                    sqlDA.SelectCommand.Parameters.Clear();
                }

                return dataSet;
            }
        }

        /// <summary>
        /// 按顺序执行多个存储过程，实现数据库事务。
        /// </summary>
        /// <param name="sqlStringList">存储过程的哈希表（value为存储过程语句，key是该语句的DbParameter[]）</param>
        /// <returns>是否执行成功</returns>
        public bool RunProcedureTran(Dictionary<DbParameter[], string> sqlStringList)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                using (DbTransaction trans = connection.BeginTransaction())
                {
                    using (DbCommand cmd = provider.CreateCommand())
                    {
                        try
                        {
                            //循环
                            foreach (KeyValuePair<DbParameter[], string> myDE in sqlStringList)
                            {
                                cmd.Connection = connection;
                                string storeName = myDE.Value;
                                DbParameter[] cmdParms = myDE.Key;
                                cmd.Transaction = trans;
                                cmd.CommandText = storeName;
                                cmd.CommandType = CommandType.StoredProcedure;

                                if (cmdParms != null)
                                {
                                    foreach (DbParameter parameter in cmdParms)
                                    {
                                        cmd.Parameters.Add(parameter);
                                    }
                                }

                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }

                            trans.Commit();
                            return true;
                        }
                        catch
                        {
                            trans.Rollback();
                            connection.Close();
                            connection.Dispose();
                            return false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 按顺序执行多个存储过程，实现数据库事务。
        /// </summary>
        /// <param name="sqlStringList">存储过程的哈希表（value为存储过程语句，key是该语句的DbParameter[]）</param>
        /// <param name="dataSet">DataSet</param>
        /// <returns>是否执行成功</returns>
        public bool RunProcedureTran(Dictionary<DbParameter[], string> sqlStringList, out DataSet dataSet)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                using (DbTransaction trans = connection.BeginTransaction())
                {
                    DataSet resultDataSet = new DataSet();

                    try
                    {
                        using (DbDataAdapter sqlDA = provider.CreateDataAdapter())
                        {
                            //循环
                            foreach (KeyValuePair<DbParameter[], string> myDE in sqlStringList)
                            {
                                string storeName = myDE.Value;
                                DbParameter[] storeParms = myDE.Key;
                                sqlDA.SelectCommand = BuildQueryCommand(connection, storeName, storeParms);
                                sqlDA.SelectCommand.Transaction = trans;
                                sqlDA.Fill(resultDataSet);
                                sqlDA.SelectCommand.Parameters.Clear();
                            }
                        }

                        trans.Commit();
                        dataSet = resultDataSet;
                        return true;
                    }
                    catch
                    {
                        dataSet = resultDataSet;
                        trans.Rollback();
                        connection.Close();
                        connection.Dispose();
                        return false;
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}
