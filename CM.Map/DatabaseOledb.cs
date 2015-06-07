using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace CM.Map
{
    public class DatabaseOledb
    {
        public OleDbConnection Conn = new OleDbConnection();

        public DatabaseOledb()
        {
            try
            {
                //string connStr = System.Configuration.ConfigurationManager.AppSettings["Oledb_ConnString"].ToString();
                string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
                Conn = new OleDbConnection(connStr);
            }
            catch(Exception ex)
            {
                Log.WriteLog(ex.Message);
            }
            
        }
        //public DatabaseOledb(string ConnectionString)
        //{
        //    try
        //    {
        //        //string connStr = System.Configuration.ConfigurationManager.AppSettings["Oledb_ConnString"].ToString();
        //        Conn = new OleDbConnection(ConnectionString);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.WriteLog(ex.Message);
        //    }

        //}

        public DatabaseOledb(string constr)
        {
            try
            {
                Conn = new OleDbConnection(constr);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {
            //打开数据库连接
            if (Conn.State == ConnectionState.Closed)
            {
                try
                {
                    //打开数据库连接
                    Conn.Open();
                }
                catch (Exception e)
                {
                    Log.WriteLog(e.Message);
                    throw e;
                }
            }
        }

        /// <summary>
        /// 测试MDB数据库链接
        /// </summary>
        /// <param name="MDB_PATH">数据库文件路径</param>
        /// <param name="Message">异常信息</param>
        /// <returns></returns>
        public static bool TestAccessConn(string MDB_PATH, ref string Message)
        {
            try
            {
                string connectingString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MDB_PATH;// CM.Map.Config.GetConfigValue("MDB_Path");
                CM.Map.DatabaseOledb acc_conn = new DatabaseOledb(connectingString);
                if (acc_conn.Conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        acc_conn.Open();
                        Message = "连接成功";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        //Close DataBase
                        //关闭数据库连接
                        acc_conn.Close();
                    }
                }
                Message = "未知原因";
                return false;
            }
            catch (Exception ex)
            {
                CM.Map.Log.WriteLog("TestAccessConn()错误>>>>" + ex.Message);
                throw ex;
            }
        }


        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            //判断连接的状态是否已经打开
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// 执行不带参数的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>     
        public int ExecuteSql(string sql)
        {
            int i = 0;
            OleDbCommand cmd = new OleDbCommand(sql, Conn);
            try
            {
                //Open();
                //打开数据库连接
                if (Conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        //打开数据库连接
                        Conn.Open();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                i = cmd.ExecuteNonQuery();
                //Close();
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Close();
                //throw e;
                Log.WriteLog(sql + "\r\nErrorMessage:" + e.Message);
            }
            return i;
        }

        public object ExecuteScalar(string sql)
        {
            object obj = null;
            OleDbCommand cmd = new OleDbCommand(sql, Conn);
            try
            {
                Open();
                obj = cmd.ExecuteScalar();
                Close();
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Close();
                throw e;
            }
            return obj;
        }

        /// <summary>
        /// 执行SQL语句，返回数据到DataSet中
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回DataSet</returns>
        public DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                Open();//打开数据连接
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, Conn);
                adapter.Fill(ds);
            }
            catch//(Exception ex)
            {
            }
            finally
            {
                Close();//关闭数据库连接
            }
            return ds;
        }

        /// <summary>
        /// 执行SQL语句，返回数据到DataSet中
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="DataSetName">自定义返回的DataSet表名</param>
        /// <returns>返回DataSet</returns>
        public DataSet GetDataSet(string sql, string DataSetName)
        {
            DataSet ds = new DataSet();
            Open();//打开数据连接
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, Conn);
            adapter.Fill(ds, DataSetName);
            Close();//关闭数据库连接
            return ds;
        }
    }
}
