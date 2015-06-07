using System;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Text;
using System.Collections.Generic;

namespace CM.Map
{
    /// <summary>
    /// 数据库通用操作类
    /// </summary>
    public class DatabaseORC
    {
        public new OracleConnection Conn = new OracleConnection();

        public DatabaseORC()
        {
            //测试方法
            //string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            //中地使用方法
            string connStr = System.Configuration.ConfigurationManager.AppSettings["connectionString"].ToString();
            Conn = new OracleConnection(connStr);
        }

        public DatabaseORC(string constr)
        {
            try
            {
                Conn = new OracleConnection(constr);
            }
            catch(Exception ex)
            {

                throw ex;
            }
        }

        #region 打开数据库连接
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {
            try
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
                        throw e;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 关闭数据库连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            try
            {
                //判断连接的状态是否已经打开
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("DatabaseORC.Close();>>>>>>>>>>>>>>");
                throw ex;
            }
           
        }
        #endregion

        /// <summary>
        /// 测试Oracle数据库链接
        /// </summary>
        /// <param name="DBIP">数据库IP</param>
        /// <param name="DBPort">数据库端口</param>
        /// <param name="DBName">数据库名称</param>
        /// <param name="DBUser">数据库用户名</param>
        /// <param name="DBPassword">数据库密码</param>
        /// <param name="Message">异常信息</param>
        /// <returns></returns>
        public static bool TestOracleConn(string DBIP, string DBPort, string DBName, string DBUser, string DBPassword, ref string Message)
        {
            string ora_conn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + DBIP + ")(PORT=" + DBPort + ")))(CONNECT_DATA=(SERVICE_NAME=" + DBName + ")));User Id=" + DBUser + ";Password=" + DBPassword + ";";
            OracleConnection ORA_Con = new OracleConnection(ora_conn);
            //打开数据库连接
            if (ORA_Con.State == ConnectionState.Closed)
            {
                try
                {
                    //打开数据库连接
                    ORA_Con.Open();
                    Message = "连接成功";
                    return true;
                }
                catch (Exception e)
                {
                    Message = e.Message;
                    return false;
                }
                finally
                {
                    //Close DataBase
                    //关闭数据库连接
                    ORA_Con.Close();
                }
            }
            Message = "未知原因";
            return false;
        }


        #region 执行带参数的SQL语句
        /// <summary>
        /// 执行不带参数的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>     
        public void ExecuteSql(string sql)
        {
            OracleCommand cmd = new OracleCommand(sql, Conn);
            try
            {
                Open();
                cmd.ExecuteNonQuery();
                Close();
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                Close();
                throw e;
            }
        }
        #endregion

        #region 执行带参数的SQL语句
        /// <summary>
        /// 执行不带参数的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>     
        public object ExecuteScalarSql(string sql)
        {
            object o = null;
            OracleCommand cmd = new OracleCommand(sql, Conn);
            try
            {
                Open();
                o = cmd.ExecuteScalar();
                Close();
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                Close();
                throw e;
            }
            return o;
        }
        #endregion

        #region 执行SQL语句，返回数据到DataSet中
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
                OracleDataAdapter adapter = new OracleDataAdapter(sql, Conn);
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
        #endregion

        #region 执行SQL语句，返回数据到自定义DataSet中
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
            OracleDataAdapter adapter = new OracleDataAdapter(sql, Conn);
            adapter.Fill(ds, DataSetName);
            Close();//关闭数据库连接
            return ds;
        }
        #endregion


    }


}