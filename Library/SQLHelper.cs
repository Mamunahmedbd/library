using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    //百度： C#  数据库访问类
    //帮助我们进行数据库访问--简化
    public class SQLHelper
    {
        //1、Create Database 建立数据库连接串
        static string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=LibraryDB;Data Source=(localdb)\\MSSQLLocalDB";
        //Method to query data from HouseDB
        public static DataSet GetData(string sqlStr)
        {
            //1、建立数据库连接串
            //string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Students;Data Source=JSZXTEACHER406-\\SQLEXPRESS";
            //2、建立数据库连接对象
            SqlConnection sqlConn = new SqlConnection(connStr);
            //3、打开连接（建立了C#程序he数据库之间的连接通道）
            sqlConn.Open();

            //4、数据查询--SqlDataAdapter（数据适配器）
            //4.1、形成SQL语句-查询全部数据
            //Console.WriteLine("a={0}",x);
            //string sqlStr = string.Format("SELECT *  FROM StudList where SName = '{0}'", this.tbSName.Text);
            //4.2、建立SqlDataAdapter对象（大卡车）
            SqlDataAdapter sqlAdpter = new SqlDataAdapter(sqlStr, sqlConn);//取哪些数据，走哪一个通道
            //4.3、取数据(表格)、卸货（ds1--表格）
            DataSet ds1 = new DataSet();
            sqlAdpter.Fill(ds1);//索引为0
            //5、关闭连接（C#程序he数据库之间的连接通道被关闭）
            sqlConn.Close();

            return ds1;
        }

        // Overload to execute parameterized query and return DataSet
        public static DataSet GetData(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        // New overload to accept a prepared SqlCommand (parameterized queries)
        public static DataSet GetData(System.Data.SqlClient.SqlCommand cmd)
        {
            DataSet ds1 = new DataSet();

            using (SqlConnection sqlConn = new SqlConnection(connStr))
            {
                cmd.Connection = sqlConn;
                using (SqlDataAdapter sqlAdpter = new SqlDataAdapter(cmd))
                {
                    sqlConn.Open();
                    sqlAdpter.Fill(ds1);
                    sqlConn.Close();
                }
            }

            return ds1;
        }

        // Execute a non-query command (INSERT/UPDATE/DELETE) using the shared connection string
        public static int ExecuteNonQuery(System.Data.SqlClient.SqlCommand cmd)
        {
            using (SqlConnection sqlConn = new SqlConnection(connStr))
            {
                cmd.Connection = sqlConn;
                sqlConn.Open();
                int affected = cmd.ExecuteNonQuery();
                sqlConn.Close();
                return affected;
            }
        }
        public static int ExecuteCmd(string sqlStr)
        {
            //1、建立数据库连接串
            //string connStr = "Integrated Security=SSPI;Initial Catalog=Students;Data Source=JSZXTEACHER406-\\SQLEXPRESS";
            //2、建立数据库连接对象
            SqlConnection sqlConn = new SqlConnection(connStr);
            //3、打开连接（建立了C#程序he数据库之间的连接通道）
            sqlConn.Open();

            //4、数据删除--SqlCommand
            //4.1、形成SQL语句-Delete语句        
            //string sqlStr = string.Format("delete from StudList where SNo ='{0}'", this.tbSNo.Text);
            //4.2、建立SqlCommand对象
            SqlCommand sqlCmd = new SqlCommand(sqlStr, sqlConn);//执行哪一个指令，走哪一个通道

            //4.3、执行指令--SqlCommand
            int n = sqlCmd.ExecuteNonQuery();
            //5、关闭连接（C#程序he数据库之间的连接通道被关闭）
            sqlConn.Close();

            return n;
        }
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
           
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
