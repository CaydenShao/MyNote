using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Common
{
    public static class AdoNetTest
    {
        public static void ConnetionTest()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // 创建连接对象
            // SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "",
                InitialCatalog = "",
                UserID = "",
                Password = ""
            };

            // 打开和关闭连接
            //SqlConnection connection = new SqlConnection(connectionString);
            using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ToString()))
            {
                connection.Open();
                connection.Close();
            }
        }

        public static void CommandTest()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 创建命令对象
                //SqlCommand command = new SqlCommand();
                //command.Connection = connection;
                SqlCommand command = connection.CreateCommand(); // 这种方式较好
                // 重要属性
                //command.CommandText = string.Empty; // 获取或设置要对数据源执行的 Transact-SQL 语句、表名或存储过程！
                //command.CommandType = CommandType.Text; // 设置你执行的SQL语句是存储过程还是T-SQL(是一个枚举)！
                //command.Parameters.Add(new SqlParameter() // 设置T_SQL语句或存储过程用到的参数
                //{
                //    ParameterName = string.Empty,
                //    Value = null
                //});
                // 拼接SQL语句
                StringBuilder sqlStr = new StringBuilder();
                sqlStr.Append("INSERT INTO user(Name) VALUES(@Name)");

                command.CommandText = sqlStr.ToString();
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = "shao"
                });
                //command.Parameters.AddWithValue("@Name", "shao");
                //command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = "shao";

                try
                {
                    connection.Open();
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
